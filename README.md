# File Organizer

A Windows console app written in C# (.NET 10) that cleans up your **Downloads** and **Desktop** folders. Pick a folder and a file category, and the app moves every matching file into the standard Windows folder for that category (images go to Pictures, documents go to Documents, and so on).

## Features

- Organize **Downloads**, **Desktop**, or both at once
- Organize one category (**Images**, **Audio**, **Videos**, **Documents**) or **All** categories
- Uses Windows' real folder locations, so it still works if your Pictures, Music, Videos, Documents or Desktop folders are redirected (for example to OneDrive)
- Never overwrites: if a file with the same name already exists at the destination, it is skipped and a message is shown
- Simple menu, repeats until you choose Exit

## Requirements

- Windows
- [.NET 10 SDK](https://dotnet.microsoft.com/download) (to build and run from source)

## How to run

### Option 1: Visual Studio

1. Download or clone this repository.
2. Open `CLI file organizer.slnx` in Visual Studio (a version with .NET 10 support).
3. Press **F5** (or the green Start button) to build and run.

### Option 2: Command line

```bash
git clone <your-repository-url>
cd "CLI file organizer/CLI file organizer"
dotnet run
```

If you downloaded the repository as a ZIP, extract it first and `cd` into the project folder that contains `CLI file organizer.csproj`.

## How to use

1. At the main menu, type `1` to continue or `2` to exit.
2. Choose which folder to organize: `Downloads`, `Desktop`, or `All` (both).
3. If you chose Downloads or Desktop, choose a file type: `Images`, `Audio`, `Videos`, `Documents`, or `All`.
4. The app prints a line for each file it moves, then returns to the main menu.

Input is not case sensitive (`images`, `Images` and `IMAGES` all work).

Example:

```
Options:
1. Continue
2. Exit

╚═> 1
Which folder do you want to organize (Downloads, Desktop, All)
> Downloads
Which file type do you want to organize (Images, Audio, Videos, Documents, All
> Images
holiday.jpg has been moved
```

Choosing `All` as the folder organizes every supported file type in both Downloads and Desktop.

## Where files go

| Category  | Extensions                                                | Destination |
|-----------|-----------------------------------------------------------|-------------|
| Images    | `.jpg` `.jpeg` `.png` `.webp` `.gif`                      | Pictures    |
| Audio     | `.mp3` `.wav` `.aiff` `.aac`                              | Music       |
| Videos    | `.mp4` `.mov` `.avi` `.mkv`                               | Videos      |
| Documents | `.docx` `.pdf` `.pptx` `.txt` `.html` `.md` `.csv` `.pages` | Documents   |

Files with any other extension are left where they are.

## Warnings

- Files are **moved**, not copied, and there is **no undo**. Try the app on a few unimportant files first.
- Only files directly inside Downloads or Desktop are organized. Subfolders and their contents are not touched.
- If a file with the same name already exists in the destination folder, the file is skipped and stays where it is.

## Known limitations

- The list of files is read once when the app starts, so files added to Downloads or Desktop while the app is running are not seen until you restart it.
- Entering something other than a number at the main menu closes the app with an error.
- The Excel extension is currently misspelled in the code (`.xlxs` instead of `.xlsx`), so Excel files are not moved by the Documents category.
- Windows only, since it relies on Windows folder locations.

## Project structure

```
CLI file organizer.slnx            Solution file
CLI file organizer/
  CLI file organizer.csproj        Project file (net10.0)
  Program.cs                       All of the app's code
```
