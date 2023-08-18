using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace wk3Assesment.Controllers{
    class Program{
         public async static Task Main(string[] args){
            Controllers newcontroller = new Controllers();
            await newcontroller.GetUsers();
        }
    }
 }
