
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MeetApplication.Controllers;
using System.Web.Http;
using System.Web.Http.Results;


namespace AppTests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void DeactivateMeeting_ShouldNotDeactivate()
        {
            var controller = new ValuesController();
            int id = 1;
            IHttpActionResult actionResult = controller.UpdateMeetingState(id);
            Assert.IsNotNull(actionResult);
            Assert.IsInstanceOfType(actionResult, typeof(NotFoundResult));
            
            
        }
    }
}
