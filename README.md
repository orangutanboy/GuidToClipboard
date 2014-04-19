Guid To Clipboard
==============

Generates a new GUID and copies it to the clipboard.

Command line argument
--------------

It accepts one command line argument which should be a single character; one of **N**, **D**, **P**, **B** or **X**. This determines the format of the GUID.
If no argument is supplied, the format is taken from the config app setting "**Format**". 
If this app setting does not exist, the default string format is used.

For more information about GUID string formats, see http://msdn.microsoft.com/en-us/library/97af8hh4(v=vs.110).aspx

Intended Usage
--------------

I use this via an external tool in Visual Studio (Tools -> External Tools)