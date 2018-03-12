using System;
using System.Collections.Generic;
using System.Linq;
using System.Collections;

class frequencyHash
{
    // Add the string to the hash table. The hash table consists of keys (column) which are strings, and values which are arrays of strings
    // the array contains all the possible values found for a given key string
    public static void addValueToHash(Hashtable hash, string key, string value)
    {
        if (hash == null) return;

        if (hash.Contains(key)) // The hash table contains the key
        {
            List<DictionaryEntry> hashVal = (List<DictionaryEntry>)hash[key]; // Get the list associated with the key

            for (int i = 0; i < hashVal.Count(); i++)
            {
                DictionaryEntry de = hashVal[i];
                if (de.Key.ToString() == value)
                {
                    // We found a key/value pair that is the same as a key/value pair we found previously,
                    // so update the frequency count for this key/value pair
                    de.Value = (int)de.Value + 1;
                    hashVal[i] = de;
                    return;
                }
            }

            // If we got here, the value wasn't in the key array, so create a new entry for it
            DictionaryEntry denew = new DictionaryEntry();
            denew.Key = value;
            int count = 1;
            denew.Value = count;
            hashVal.Add(denew);
            return;

        }
        else // The hash table doesn't contain this key yet
        {
            List<DictionaryEntry> newHashVal = new List<DictionaryEntry>(); // Create a new list to add to the hash
            DictionaryEntry de = new DictionaryEntry();
            de.Key = value;
            int count = 1;
            de.Value = count;

            newHashVal.Add(de); // Add the value to the list
            hash.Add(key, newHashVal); // Add the list to the hash table
        }
    }

    // Print the contents of the hash table
    public static void dumpHashTable(Hashtable hash, string outputfile)
    {
        Console.WriteLine("Beginning dumpHashTable...");
        foreach (DictionaryEntry de in hash)
        {
            bool skip = false;
            string[] skipList = { "ID" };
            for (int i = 0; i < skipList.Length; i++) if (de.Key.ToString() == skipList[i]) skip = true;

            if (skip) continue;

            auxFileWriterLib.appendToFile(outputfile, "Key: " + de.Key.ToString() + Environment.NewLine);
            List<DictionaryEntry> list = (List<DictionaryEntry>)de.Value;

            for (int i = 0; i < list.Count(); i++)
            {
                DictionaryEntry ival = list[i];
                auxFileWriterLib.appendToFile(outputfile, "\t" + ival.Key.ToString() + " ; FREQ: " + ival.Value.ToString() + Environment.NewLine);
            }
            auxFileWriterLib.appendToFile(outputfile, Environment.NewLine);
        }
        Console.WriteLine("Completed dumpHashTable.");
    }
}