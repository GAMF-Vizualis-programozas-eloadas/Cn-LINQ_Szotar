using System;
using System.Collections.Generic;
using System.Linq;

namespace CnLINQ_Szotar
{
  /// <summary>
  /// Néhány szótárfunkciót megvalósító egyszerű program, melynek célja LINQ to objects
  /// használatának demonstrálása. Egy generikus lista objektumban szópárokat tárolunk,
  /// majd lekérdezzük, hogy mely párokban szerepel az angol oldalon a nice szó, méret 
  /// alapján tovább szűkítjük a találati halmazt, amit a magyar szavak szerint abc 
  /// sorrendben állítunk elő.
  /// </summary>


  /// <summary>
  /// Szópár tárolását megvalósító osztály.
  /// </summary>
  class Párok
  {
    public string Angol { get; set; }
    public string Magyar { get; set; }
    public Párok(string Angol, string Magyar)
    {
      this.Angol = Angol;
      this.Magyar = Magyar;
    }
  }

  /// <summary>
  /// Itt található a fő metódus.
  /// </summary>
  class SzotarProgram
  {
    /// <summary>
    /// Generikus lista a szópárok tárolsásához.
    /// </summary>
    static List<Párok> Szótár = new List<Párok>();

    /// <summary>
    /// Fő metódus. 
    /// </summary>
    static void Main(string[] args)
    {
      // Lista feltöltése szópárokkal.
      Létrehoz();
      // Lekérdezés - az eredemény egy lista formájában jelenik meg, amely objektum 
      // megvalósítja az IEnumerable interfészt.
      IEnumerable<string> Eredmény =
        from x in Szótár
        where x.Angol == "nice" &&
                     x.Magyar.Length < 8
        orderby x.Magyar
        select x.Magyar;
      // A kapott eredmény megjelenítése a konzolon. 
      Console.Write("nice= ");
      foreach (var s in Eredmény)
        Console.Write("{0}, ", s);
      Console.ReadLine();
    }

    /// <summary>
    /// Feltölti a listát néhány szópárral.
    /// </summary>
    private static void Létrehoz()
    {
      Szótár.Add(new Párok("sun", "nap"));
      Szótár.Add(new Párok("day", "nap"));
      Szótár.Add(new Párok("nice", "kellemes"));
      Szótár.Add(new Párok("nice", "aranyos"));
      Szótár.Add(new Párok("nice", "helyes"));
    }
  }

}
