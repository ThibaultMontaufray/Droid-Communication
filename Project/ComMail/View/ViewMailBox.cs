using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MimeKit;
using MailKit;
using MimeKit.Text;

namespace Droid_communication
{
    public partial class ViewMailBox : UserControl
    {
        #region Attributes
        private InterfaceEmail _intEmail;
        #endregion

        #region Properties
        public InterfaceEmail InterfaceEmail
        {
            get { return _intEmail; }
            set
            {
                _intEmail = value;
                folderTreeView.InterfaceEmail = value;
            }
        }
        #endregion

        #region Constructor
        public ViewMailBox()
        {
            Init();
        }
        public ViewMailBox(InterfaceEmail intEmail)
        {
            _intEmail = intEmail;
            Init();
            folderTreeView.InterfaceEmail = _intEmail;
        }
        #endregion

        #region Methods public
        public void RefreshData()
        {
            folderTreeView.LoadFolders();
        }
        public void ChangeLanguage()
        {

        }
        #endregion

        #region Methods private
        private void Init()
        {
            InitializeComponent();

            folderTreeView.FolderSelected += FolderSelected;
            messageList.MessageSelected += MessageSelected;
        }
        private void RenderMultipartRelated(MultipartRelated related)
        {
            var root = related.Root;
            var multipart = root as Multipart;
            var text = root as TextPart;

            if (multipart != null)
            {
                // Note: the root document can sometimes be a multipart/alternative.
                // A multipart/alternative is just a collection of alternate views.
                // The last part is the format that most closely matches what the
                // user saw in his or her email client's WYSIWYG editor.
                for (int i = multipart.Count; i > 0; i--)
                {
                    var body = multipart[i - 1] as TextPart;

                    if (body == null)
                        continue;

                    // our preferred mime-type is text/html
                    if (body.ContentType.IsMimeType("text", "html"))
                    {
                        text = body;
                        break;
                    }

                    if (text == null)
                        text = body;
                }
            }

            // check if we have a text/html document
            if (text != null)
            {
                if (text.ContentType.IsMimeType("text", "html"))
                {
                    // replace image src urls that refer to related MIME parts with "data:" urls
                    // Note: we could also save the related MIME part content to disk and use
                    // file:// urls instead.
                    var ctx = new MultipartRelatedImageContext(related);
                    var converter = new HtmlToHtml() { HtmlTagCallback = ctx.HtmlTagCallback };
                    var html = converter.Convert(text.Text);

                    webBrowser.DocumentText = html;
                }
                else
                {
                    RenderText(text);
                }
            }
            else
            {
                // we don't know how to render this type of content
                return;
            }
        }
        private async void RenderMultipartRelated(IMailFolder folder, UniqueId uid, BodyPartMultipart bodyPart)
        {
            // download the entire multipart/related for simplicity since we'll probably end up needing all of the image attachments anyway...
            var related = await folder.GetBodyPartAsync(uid, bodyPart) as MultipartRelated;

            RenderMultipartRelated(related);
        }
        private void RenderText(TextPart text)
        {
            string html;

            if (text.IsHtml)
            {
                // the text content is already in HTML format
                html = text.Text;
            }
            else if (text.IsFlowed)
            {
                var converter = new FlowedToHtml();
                string delsp;

                // the delsp parameter specifies whether or not to delete spaces at the end of flowed lines
                if (!text.ContentType.Parameters.TryGetValue("delsp", out delsp))
                    delsp = "no";

                if (string.Compare(delsp, "yes", StringComparison.OrdinalIgnoreCase) == 0)
                    converter.DeleteSpace = true;

                html = converter.Convert(text.Text);
            }
            else
            {
                html = new TextToHtml().Convert(text.Text);
            }

            webBrowser.DocumentText = html;
        }
        private async void RenderText(IMailFolder folder, UniqueId uid, BodyPartText bodyPart)
        {
            var entity = await folder.GetBodyPartAsync(uid, bodyPart);

            RenderText((TextPart)entity);
        }
        private void Render(IMailFolder folder, UniqueId uid, BodyPart body)
        {
            var multipart = body as BodyPartMultipart;

            if (multipart != null && body.ContentType.IsMimeType("multipart", "related"))
            {
                RenderMultipartRelated(folder, uid, multipart);
                return;
            }

            var text = body as BodyPartText;

            if (multipart != null)
            {
                if (multipart.ContentType.IsMimeType("multipart", "alternative"))
                {
                    // A multipart/alternative is just a collection of alternate views.
                    // The last part is the format that most closely matches what the
                    // user saw in his or her email client's WYSIWYG editor.
                    for (int i = multipart.BodyParts.Count; i > 0; i--)
                    {
                        var multi = multipart.BodyParts[i - 1] as BodyPartMultipart;

                        if (multi != null && multi.ContentType.IsMimeType("multipart", "related"))
                        {
                            if (multi.BodyParts.Count == 0)
                                continue;

                            var start = multi.ContentType.Parameters["start"];
                            var root = multi.BodyParts[0];

                            if (!string.IsNullOrEmpty(start))
                            {
                                // if the 'start' parameter is set, it overrides the default behavior of using the first
                                // body part as the main document.
                                root = multi.BodyParts.OfType<BodyPartText>().FirstOrDefault(x => x.ContentId == start);
                            }

                            if (root != null && root.ContentType.IsMimeType("text", "html"))
                            {
                                Render(folder, uid, multi);
                                return;
                            }

                            continue;
                        }

                        text = multipart.BodyParts[i - 1] as BodyPartText;

                        if (text != null)
                        {
                            RenderText(folder, uid, text);
                            return;
                        }
                    }
                }
                else if (multipart.BodyParts.Count > 0)
                {
                    // The main message body is usually the first part of a multipart/mixed.
                    Render(folder, uid, multipart.BodyParts[0]);
                }
            }
            else if (text != null)
            {
                RenderText(folder, uid, text);
            }
        }
        #endregion

        #region Event
        private void FolderSelected(object sender, FolderSelectedEventArgs e)
        {
            messageList.OpenFolder(e.Folder);
        }
        private void MessageSelected(object sender, MessageSelectedEventArgs e)
        {
            Render(e.Folder, e.UniqueId, e.Body);
        }
        #endregion
    }
}
