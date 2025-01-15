using Entities;
using Utility;
namespace DAOs
{
    public class DAORicette : IDAO
    {
        private Database db;
        private static DAORicette instance = null;

        private DAORicette()
        {
            db = new Database("Generation");
        }

        public static DAORicette GetInstance()
        {
            instance ??= new DAORicette();
            return instance;
        }

        public bool CreateRecord(Entity entity)
        {
            var ricetta = (Ricetta)entity;
            string query = $@"INSERT INTO Ricette 
            (nome, categoria, tipoCucina, tempoPreparazione, ingredienti, istruzioni, difficolta) 
            VALUES (
            '{StringUtils.EscapeSingleQuotes(ricetta.Nome)}',
            '{StringUtils.EscapeSingleQuotes(ricetta.Categoria)}',
            '{StringUtils.EscapeSingleQuotes(ricetta.TipoCucina ?? "")}',
            {ricetta.TempoPreparazione},
            '{StringUtils.EscapeSingleQuotes(ricetta.Ingredienti)}',
            '{StringUtils.EscapeSingleQuotes(ricetta.Istruzioni)}',
            '{StringUtils.EscapeSingleQuotes(ricetta.Difficolta ?? "")}')";
            return db.UpdateDb(query);
        }

        public bool DeleteRecord(int recordId)
        {
            return db.UpdateDb($"DELETE FROM Ricette WHERE Id = {recordId}");
        }

        public Entity? FindRecord(int recordId)
        {
            var result = db.ReadDb($"SELECT * FROM Ricette WHERE Id = {recordId}");
            if (result == null || result.Count == 0) return null;

            var ricetta = new Ricetta();
            ricetta.FromDictionary(result[0]);
            return ricetta;
        }

        public List<Entity> GetRecords()
        {
            var result = db.ReadDb("SELECT * FROM Ricette ORDER BY nome");
            var entities = new List<Entity>();

            if (result != null)
            {
                foreach (var row in result)
                {
                    var ricetta = new Ricetta();
                    ricetta.FromDictionary(row);
                    entities.Add(ricetta);
                }
            }
            return entities;
        }

        public bool UpdateRecord(Entity entity)
        {
            var ricetta = (Ricetta)entity;
            string query = $@"UPDATE Ricette SET 
            nome = '{StringUtils.EscapeSingleQuotes(ricetta.Nome)}',
            categoria = '{StringUtils.EscapeSingleQuotes(ricetta.Categoria)}',
            tipoCucina = '{StringUtils.EscapeSingleQuotes(ricetta.TipoCucina ?? "")}',
            tempoPreparazione = {ricetta.TempoPreparazione},
            ingredienti = '{StringUtils.EscapeSingleQuotes(ricetta.Ingredienti)}',
            istruzioni = '{StringUtils.EscapeSingleQuotes(ricetta.Istruzioni)}',
            difficolta = '{StringUtils.EscapeSingleQuotes(ricetta.Difficolta ?? "")}'
            WHERE Id = {ricetta.Id}";
            return db.UpdateDb(query);
        }
    }
}