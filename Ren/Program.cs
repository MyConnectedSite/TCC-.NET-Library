using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TCC2.API;
using TCC2.API.Filesystem;

namespace Ren
{
    class Program
    {
        static void Main(string[] args)
        {
            Session session = new Session("https://www.myconnectedsite.com/tcc");

            session.Open("yourloginshortname","yourorgshortname","yourpassword");

            GetFilespace getFilespace = new GetFilespace(session);
            GetFilespaceResult getFilespaceResult = getFilespace.Call("yourfilespaceshortname", "yourorg");
            

            Ren ren=new Ren(session);

            ren.Call(getFilespaceResult.FilespaceId, "/oldfile.txt",getFilespaceResult.FilespaceId,"/newfile.txt",false,false);

            session.Close();
        }
    }
}
