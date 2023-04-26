using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;
using System.Data.SqlClient;

namespace WebApplication1.Controllers
{
    public class StudentController : Controller
    {
        IDateServices _services;//instance 
       List<CollegeModel> colleges = new List<CollegeModel>();
        List<StudentsModel> colleges1 = new List<StudentsModel>();
        public StudentController(IDateServices dateServices) { 
        _services= dateServices;

        }
        [HttpGet]
        public IActionResult AddToDatabase()
        {
            return View();

        }
        //making action to save to db
        //form always uses POST
        [HttpPost]
        public IActionResult AddToDatabase(StudentsModel student) //student ma form diyeko data aaucha
        {
            string connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=BMC;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False"; //1.connection string
            SqlConnection conn = new SqlConnection(connectionString); //2connection
            conn.Open(); //3opening connection
            string command = "insert into Student Values ('suman', 'kalanki', 'Csit')"; //sql command
              SqlCommand cmd = new SqlCommand(command, conn); //4. Sql Command this turn string above to sql command
            cmd.ExecuteNonQuery(); //because its not a query now
            conn.Close();
            return View();

        }


        public IActionResult GetDate()
        {
            //IDateServices dateServicecs= new N        DateServicecs();  //tight coupling  //has already used mmemroy
            //only use memory when used
            //if Ndate servicecs used here--tightly coupling--bad practice--to remove this DI used
            //to remove tight coupling IOC(inversion of control)
    
            return Content(_services.GetDate().ToString());//DI used
            
        }
        
        public IActionResult College(string[] collegeDetail)
        {
            IDateServices dateServicecs = new NDateServicecs();
            StreamReader sr = new StreamReader("wwwroot/myfile.txt");
            string line = sr.ReadLine();
            while (line != null)
            {
                string[] CollegeDetail = line.Split(',');
                CollegeModel College = new CollegeModel();//making model
                College.CollegeId = int.Parse(CollegeDetail[0]);
                College.CollegeName = CollegeDetail[1];
                College.Address = CollegeDetail[2];
                College.University = CollegeDetail[3];
                colleges.Add(College);
                line = sr.ReadLine();
            }
            sr.Close();
            return View(colleges);
        }
        public IActionResult AddCollege() //form dine
        {
            IDateServices dateServicecs = new NDateServicecs();
            return View();
        }
        [HttpPost]
        public ActionResult CreateCollege(CollegeModel College)
        {
            string dataToSave = College.CollegeId + "," + College.CollegeName + "," + College.Address + ", " + College.University;
            StreamWriter sw = new StreamWriter("wwwroot/myfile.txt", true);
            sw.WriteLine(dataToSave);
            sw.Close();
            return RedirectToAction("College");
        }
        //Get: college
        public ActionResult Index()
        {
            IDateServices dateServicecs = new NDateServicecs();
            IDateServices dateServicecs1 = new DateServicecs();

            //fetching the clz from the list
            return View(colleges.OrderBy(s=>s.CollegeId).ToList());
        }
        
        public ActionResult Edit(int id)
        {
            //here, get the student from the database in the real application

            //getting a student from collection for demo purpose
       
            //var clz = colleges.Where(s => s.CollegeId == id).FirstOrDefault();
            
           // return View(clz);
           
            var clz = colleges.FirstOrDefault(i => i.CollegeId == id);
            if (clz == null)
            {
                return NotFound();
            }

            return View(clz);




        }
        //[HttpPost]
        //public ActionResult Edit(CollegeModel kolege)
        //{
        //    //update student in DB using EntityFramework in real-life application

        //    //update list by removing old student and adding updated student for demo purpose
        //    var clz = colleges.Where(s => s.CollegeId == kolege.CollegeId).FirstOrDefault();
        //    colleges.Remove(clz);
        //    colleges.Add(kolege);

        //    return RedirectToAction("College");
        //}
    }

}
