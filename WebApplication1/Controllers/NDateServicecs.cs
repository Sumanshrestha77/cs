namespace WebApplication1.Controllers
{
    public class NDateServicecs:IDateServices
    {
        public DateTime GetDate()
        {   
            return System.DateTime.Now.AddYears(56); //geting date of system
            //object is made in StudentController
            //tight coupling to loose couping using DI
        }
    }
}
