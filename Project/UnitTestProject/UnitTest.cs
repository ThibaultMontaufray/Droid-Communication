using Droid_communication;
using NUnit.Framework;
using System;
using System.Windows.Forms;

namespace UnitTestProject
{
    [TestFixture]
    public class UnitTest
    {
        [Test]
        public void TestUTRuns()
        {
            Assert.IsTrue(true);
        }
        [Test]
        public void Test_outlook_interface()
        {
            try
            {
                OutlookInterface oi = new OutlookInterface();
                Assert.IsTrue(true);
            }
            catch (Exception exp)
            {
                Assert.Fail(exp.Message);
            }
        }
        [Test]
        public void Test_demo_outlook()
        {
            try
            {
                DemoOutlook deou = new DemoOutlook();
                Assert.IsTrue(true);
            }
            catch (Exception exp)
            {
                Assert.Fail(exp.Message);
            }
        }
        [Test]
        public void Test_outlook_send_mail()
        {
            try
            {
                OutlookInterface.ACTION_130_envoyer_mail("mail de test", new System.Collections.Generic.List<string>() { "toto@totomail.com" }, "Je suis une mouette");
                Assert.IsTrue(true);
            }
            catch (Exception exp)
            {
                Assert.Fail(exp.Message);
            }
        }
        [Test]
        public void Test_outlook_delete_mail()
        {
            try
            {
                OutlookInterface.ACTION_132_supprimer_mail("mail de test", "moi", DateTime.Now, "inbox");
                Assert.IsTrue(true);
            }
            catch (Exception exp)
            {
                Assert.Fail(exp.Message);
            }
        }
        [Test]
        public void Test_demo_slack_interface()
        {
            try
            {
                Interface_slack slack = new Interface_slack("");
                slack.PostMessage("je suis une mouette");
                Assert.IsTrue(true);
            }
            catch (Exception exp)
            {
                Assert.Fail(exp.Message);
            }
        }
        [Test]
        public void Test_demo_slack_demo()
        {
            try
            {
                SlackDemo sd = new SlackDemo();
                Assert.IsTrue(true);
            }
            catch (Exception exp)
            {
                Assert.Fail(exp.Message);
            }
        }
        //[Test]
        //public void Test_lync_interface()
        //{
        //    try
        //    {
        //        Assert.IsTrue(true);
        //    }
        //    catch (Exception exp)
        //    {
        //        Assert.Fail(exp.Message);
        //    }
        //}
    }
}
