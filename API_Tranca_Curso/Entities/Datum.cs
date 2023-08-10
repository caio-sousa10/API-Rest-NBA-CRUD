namespace API_Tranca_Curso.Entities;

public class Datum
{
    public int id { get; set; }
    public string abbreviation { get; set; }
    public string city { get; set; }
    public string conference { get; set; }
    public string division { get; set; }
    public string full_name { get; set; }
    public string name { get; set; }
    public bool Deletado { get; set; }


    public virtual void Atualiza(string abr, string cidade, string conf, string divisao, string nomeCom, string nome)
    {
        abbreviation = abr;
        city = cidade;
        conference = conf;
        division = divisao;
        full_name = nomeCom;
        name = nome;
        Deletado = false;
    }

    public void Deletar(int id_Desejada)
    {
        Deletado = true;
    }
}

public class Root : Datum
{
    public List<Datum> data { get; set; }
}
