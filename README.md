# auxiliary-csharp-libraries
some auxiliary libraries for Visual Studio C#

Usage:

1.) Clone into the desired directory

2.) When you open a Visual Studio C# console application, select `Project > Add Exhisting Item` and select which file you want to use

(more instructions will be added later)

#### auxAccDbLib.cs

#### auxFileWriterLib.cs

#### auxRegexLib.cs

#### frequencyHash.cs

```
using System.Collections;

...

// Declare a hash table
Hashtable hash = new Hashtable();

string key;
string value;

...
// Add to the frequency hash
frequencyHash.addValueToHash(hash, key, value);


// Dump the contents of the hash table
frequencyHash.dumpHashTable(hash, outfile2);
```
