# SimpleRijndael
 Simple use of the Rijndael algorithm in .NET

Example of usage:

```
string original = "This is a text to encrypt!";
string password = "ThisIsMyPassword";

string encriptado = SimpleRijndael.Encrypt(original, password);
string desencriptado = SimpleRijndael.Decrypt(encriptado, password);
```
