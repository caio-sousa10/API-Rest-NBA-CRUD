using API_Tranca_Curso.Entities;

namespace API_Tranca_Curso.Persistance;

public class APIDBContext
{
    public List<Datum> data { get; set; }

    public APIDBContext() 
    {
        data = new List<Datum>();
    }

    
}

