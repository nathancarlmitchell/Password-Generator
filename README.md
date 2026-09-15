# Password Generator

A small Windows Forms tool for generating random passwords, with a few different generation
modes plus an optional "mangle" (leetspeak) transform.

## Download

Password Generator targets .NET Framework 4.8, which ships with Windows itself — nothing to
download or install beyond the app on a normal Windows 11 machine.

- **[dist/PasswordGenerator-Setup.exe](dist/PasswordGenerator-Setup.exe)** — installer. Run it,
  follow the wizard; it adds a Start Menu shortcut and a normal Add/Remove Programs entry. See
  [Installing](#installing) below.
- **[dist/PasswordGenerator-Portable.zip](dist/PasswordGenerator-Portable.zip)** — portable. No
  install, no admin rights, nothing written outside its own folder. See
  [Running the portable version](#running-the-portable-version) below.

Both are built from the same source in this repo (see [Building](#building) for how to regenerate
them yourself).

### Installing

1. Download `dist/PasswordGenerator-Setup.exe`.
2. Run it. Windows may show a SmartScreen prompt since the installer isn't code-signed — click
   **More info > Run anyway** if so.
3. Follow the wizard (it'll ask whether to install just for you or for all users, and offers an
   optional desktop shortcut).
4. Launch Password Generator from the Start Menu. Uninstall later from Settings > Apps, like any
   other installed program.

### Running the portable version

1. Download `dist/PasswordGenerator-Portable.zip`.
2. Extract it anywhere — a folder, a USB drive, a network share. Keep `PasswordGenerator.exe`,
   `PasswordGenerator.exe.config`, and `word-list.csv` together in the same folder — the `.config`
   file declares which .NET Framework version to run against, and `word-list.csv` is what "Use
   Dictionary" mode reads its words from.
3. Run `PasswordGenerator.exe` directly. No installer, no admin rights, and nothing is written to
   the system other than the same `%LOCALAPPDATA%\PasswordGenerator\` settings folder the
   installed version uses (the current mode, options, and window state) — delete that folder to
   fully reset or remove all trace of having run it.
4. To update, just replace all three files with a newer extract.

## Features

**Generate** creates a new password using whichever mode is checked:

| Mode | Description | Example |
| --- | --- | --- |
| Default | Office-365-style: 4 letters + 4 digits | `Mune2297` |
| Default + Increased complexity | Character length letters (8 by default) + 6 digits | `Dusesoqo468954` |
| Use Dictionary *(on by default)* | Two common English words (Min/Max word length below) + 2 digits | `RehireIodine78` |
| Default + More random | Fully randomized letters/digits, 8 characters | `iiIi3duE` |
| Default + More random + Increased complexity | Fully randomized, 12 characters | `LEAVM10BiEnQ` |

- **Default / Use Dictionary** are mutually exclusive — checking one unchecks the other, since
  they're the two different sources a password's base letters/words come from. While Use
  Dictionary is checked, Increased complexity and More random are disabled (they only apply to
  Default's letter-pattern generation, not dictionary words) and get unchecked if they were on.
- **Include special character** appends one special character (`!@#$%^&*()?`) to whichever
  password was just generated.
- **Batch count** generates more than one password at once (1-100) — each line in the output
  box is an independent password in whatever mode is currently selected.
- **Character length** (4-32, default 8) controls how many letters Increased complexity puts in
  front of its fixed 6-digit suffix — only enabled while Increased complexity is checked.
- **Min/Max word length** (3-9, default 3-7) controls which words `word-list.csv` supplies to
  Dictionary mode — the two spinners keep each other in sync so Min can never exceed Max, and
  both are only enabled while Use Dictionary is checked.
- **Mangle (M@NGL3)** applies a leetspeak-style substitution (`a`→`@`, `e`→`3`, `i`→`1`, `s`→`$`,
  `o`→`0`) to every matching character in each password as it's generated — checked once, it
  applies to every line of a batch, not just a single password.
- **Copy to clipboard** copies the current password (or the whole batch).

Dictionary-mode words come from the [EFF long wordlist](https://www.eff.org/dice) for
dice-generated passphrases (`word-list.csv`, CC BY 3.0 US, 7,771 words after removing a
handful — `crazy`, `fool`, `hate`, `racism`, `badass` — that didn't fit this app's own
dictionary-word policy). Passwords are generated with a cryptographically secure random
number generator (`RNGCryptoServiceProvider`), not `System.Random`.

## Requirements

- Windows
- .NET Framework 4.8

## Building

Open `PasswordGenerator.sln` in Visual Studio (2019+) and build, or from the command line:

```
msbuild PasswordGenerator\PasswordGenerator.csproj /p:Configuration=Release
```

The word list used by "Use Dictionary" (`word-list.csv`) needs to sit next to the built `.exe` —
the project's `Content` item already copies it to the output directory on build.

### Regenerating the distributables in `dist/`

After a Release build, `PasswordGenerator\bin\Release\` holds `PasswordGenerator.exe`,
`PasswordGenerator.exe.config`, and `word-list.csv` — zip those three together for
`dist/PasswordGenerator-Portable.zip`. Then, with the free
[Inno Setup](https://jrsoftware.org/isinfo.php) compiler installed:

```
ISCC.exe installer\PasswordGenerator.iss
```

produces `installer\Output\PasswordGenerator-Setup.exe` — copy that to
`dist/PasswordGenerator-Setup.exe`.
