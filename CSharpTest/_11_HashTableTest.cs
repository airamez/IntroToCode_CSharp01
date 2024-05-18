using DataStructures.HashTable;

namespace Tests.HashSet;

public class HashTableTest
{

  [Test]
  public void HashTableTests()
  {
    var myHashTable = new MyHashTable();

    Assert.That(myHashTable.Size, Is.EqualTo(0));

    myHashTable.Add(1);
    Assert.That(myHashTable.Size, Is.EqualTo(1));
    Assert.That(myHashTable.Contains(1), Is.True);
    Assert.That(myHashTable.Contains(2), Is.False);

    myHashTable.Add(5);
    Assert.That(myHashTable.Size, Is.EqualTo(2));
    Assert.That(myHashTable.Contains(1), Is.True);
    Assert.That(myHashTable.Contains(2), Is.False);
    Assert.That(myHashTable.Contains(5), Is.True);

    myHashTable.Remove(1);
    Assert.That(myHashTable.Size, Is.EqualTo(1));
    Assert.That(myHashTable.Contains(1), Is.False);
    Assert.That(myHashTable.Contains(2), Is.False);
    Assert.That(myHashTable.Contains(5), Is.True);

    myHashTable.Add(2);
    Assert.That(myHashTable.Size, Is.EqualTo(2));
    Assert.That(myHashTable.Contains(1), Is.False);
    Assert.That(myHashTable.Contains(2), Is.True);
    Assert.That(myHashTable.Contains(5), Is.True);

    myHashTable.Remove(1);

    myHashTable.Add(2);
    Assert.That(myHashTable.Size, Is.EqualTo(2));
    Assert.That(myHashTable.Contains(1), Is.False);
    Assert.That(myHashTable.Contains(2), Is.True);
    Assert.That(myHashTable.Contains(5), Is.True);

    myHashTable.Add(1);
    myHashTable.Add(9);
    myHashTable.Add(8);
    myHashTable.Add(7);
    myHashTable.Add(50);
    myHashTable.Add(6);
    Assert.That(myHashTable.Size, Is.EqualTo(8));
    Assert.That(myHashTable.Contains(1), Is.True);
    Assert.That(myHashTable.Contains(9), Is.True);
    Assert.That(myHashTable.Contains(8), Is.True);
    Assert.That(myHashTable.Contains(7), Is.True);
    Assert.That(myHashTable.Contains(50), Is.True);
    Assert.That(myHashTable.Contains(6), Is.True);

  }
}