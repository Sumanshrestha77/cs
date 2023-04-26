namespace WebApplication1.Controllers
{
    public class DateServicecs:IDateServices
    {
        public DateTime GetDate()
        {   
            return System.DateTime.Now; //geting date of system
            //object is made in StudentController
        }
    }
}
