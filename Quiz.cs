using System.Security.Cryptography.X509Certificates;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using System.Threading.Tasks;
using System.Reflection.Metadata.Ecma335;
using System.Data;
using Microsoft.VisualBasic;


//Innehåller även kod för att ladda Json-filen till programmet.  
public class Subject
{   
    public string Name {get; set; }
    public List<Question> score = new List<Question>();//Ändra till dictionary istället?
      

    public Subject(string name)
    {
        Name = name;        
    }  

} 

    
    
   
    