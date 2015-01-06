using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using NUnit.Framework;

namespace WcfServiceForIOS
{
    [TestFixture]
    public class DomainTests
    {
        
        private void addx(){
            Exception e=new Exception ("good ni");
            WcfLog.Log(logLevel.Error, e);
        }
        [Test]
        public void getuseridTests() {
            IServiceForIOSPoster poser = new ServiceForIOSPoster();
            Model.Poster p = new Model.Poster();
            p.User_ID = 22;
            p.PosterInput = "sdf";

            Assert.AreEqual(Model.ConnectStatus.ActionSuccess, poser.SavePoster(p));
        }
        [Test]
        public void getGetPosterByUserIDTests() {
         IServiceForIOSPoster poser = new ServiceForIOSPoster();
         poser.GetPosterByUserID("24", 0, 10);
        }
    }
}