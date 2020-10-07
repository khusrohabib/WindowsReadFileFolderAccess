# C# Program to Read Access Rights for Folders and Files

The program takes a folder path as an input and recuresively traverses each sub folder and thes files contained in it to generate the access rights for each folder and file. 

# Steps to Run
__1. Build the project or run the executeable file provided in the repository under the Test folder__

__2. Execute the following in a terminal window to generate the output in a text file__

```
accessinfo.exe > output.txt
```
OR the following to print it in the temrinal window
```
accessinfo.exe
```
__3. System will then ask for the folder path to be traversed__
```
Enter Folder Path: 
C:\My Project
```


__4. output.txt is generated in the following format__
```
Type,Name,Path,User,Rights,Authorization
Directory, .git, C:\My Project\.git, NT AUTHORITY\SYSTEM, FullControl, Allow
Directory, .git, C:\My Project\.git, BUILTIN\Administrators, FullControl, Allow
Directory, .git, C:\My Project\.git, EO\User1, FullControl, Allow
Directory, hooks, C:\My Project\.git\hooks, NT AUTHORITY\SYSTEM, FullControl, Allow
Directory, hooks, C:\My Project\.git\hooks, BUILTIN\Administrators, FullControl, Allow
Directory, hooks, C:\My Project\.git\hooks, EO\User1, FullControl, Allow
File,applypatch-msg.sample, C:\My Project\.git\hooks\applypatch-msg.sample, NT AUTHORITY\SYSTEM, FullControl,Allow
File,applypatch-msg.sample, C:\My Project\.git\hooks\applypatch-msg.sample, BUILTIN\Administrators, FullControl,Allow
File,applypatch-msg.sample, C:\My Project\.git\hooks\applypatch-msg.sample, EO\10101, FullControl,Allow
File,commit-msg.sample, C:\My Project\.git\hooks\commit-msg.sample, NT AUTHORITY\SYSTEM, FullControl,Allow
File,commit-msg.sample, C:\My Project\.git\hooks\commit-msg.sample, BUILTIN\Administrators, FullControl,Allow
.
.
.

```
