using System.Collections;

internal class Program
{
    private static void Main(string[] args)
    {
        Employee director = new Employee { Name = "Öncü Özmete" };
        Employee manager = new Employee { Name = "Elif Karadağ" };
        Employee senior = new Employee { Name = "Emrah Kerim" };
        Employee junior1 = new Employee { Name = "Ümmühan Kurt" };
        Employee junior2 = new Employee { Name = "Cagatay Gurses" };

        Concractor merve = new Concractor { Name = "Merve" };
        Concractor eren = new Concractor { Name = "Eren" };


        director.AddSubordinate(manager);
        manager.AddSubordinate(senior);
        senior.AddSubordinate(junior1);
        senior.AddSubordinate(junior2);
        junior1.AddSubordinate(merve);
        junior1.AddSubordinate(eren);

        Console.WriteLine(director.Name + "(director)");

        foreach (Employee yonetici in director)
        {
            Console.WriteLine("  {0}(manager)", yonetici.Name);

            foreach (Employee seniorr in yonetici)
            {
                Console.WriteLine("    {0}(senior)", seniorr.Name);

                foreach (Employee junior in senior)
                {
                    Console.WriteLine("      {0}(junior)", junior.Name);

                    foreach (IPerson junorCalisani in junior)
                    {
                        Console.WriteLine("        {0}", junorCalisani.Name);
                    }
                }
            }
        }
    }
}

interface IPerson
{
    string Name { get; set; }
}

class Concractor : IPerson
{
    public string Name { get ; set; }
}

class Employee : IPerson, IEnumerable<IPerson>
{
    /*
      bir kişi gibi davranıp aynı zamanda içindeki alt çalışanları da koleksiyon olarak yönetebileceği anlamına gelir.
     */

    List<IPerson> _subordinates = new List<IPerson>(); /*Employee sınıfının alt çalışanlarını saklamak için kullanılır.*/

    public void AddSubordinate(IPerson person)
    {
        _subordinates.Add(person);
    }

    public void RemoveSubordinate(IPerson person)
    {
        _subordinates.Remove(person);
    }

    public IPerson GetSubOrdinate(int index)
    {
        return _subordinates[index];
    }

    public string Name { get; set ; }

    public IEnumerator<IPerson> GetEnumerator()
    {
        foreach (var subordinate in _subordinates)
        {
            yield return subordinate; /* _subordinates listesindeki her bir elemanı tek tek döndürmeye olanak sağlar. 
                                         Bu şekilde, Employee sınıfının alt çalışanlarını tek tek ele alabilir ve bu alt çalışanları döndürebilirsiniz.
                                       */        }

    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        throw new NotImplementedException();
    }
}