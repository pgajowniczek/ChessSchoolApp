using ChessSchoolApp.Entities;
using ChessSchoolApp.Repositories;
using Newtonsoft.Json;

public class FileRepository<T> : IRepository<T> where T : class, IEntity
{
    private readonly string _fileName;
    private readonly List<T> _items;

    public FileRepository()
    {
        _fileName = typeof(T).Name + ".json";
        if (!File.Exists(_fileName))
        {
            File.Create(_fileName).Close();
            _items = new List<T>();
        }
        else
        {
            string json = File.ReadAllText(_fileName);
            _items = JsonConvert.DeserializeObject<List<T>>(json);
        }
    }
    public void Add(T item)
    {
        _items.Add(item);
        Save();
    }

    public IEnumerable<T> GetAll()
    {
        return _items;
    }

    public T GetById(int id)
    {
        return _items.FirstOrDefault(x => x.Id == id);
    }

    public void Remove(T item)
    {
        _items.Remove(item);
        Save();
    }

    public void Save()
    {
        string json = JsonConvert.SerializeObject(_items);
        File.WriteAllText(_fileName, json);
    }
}

