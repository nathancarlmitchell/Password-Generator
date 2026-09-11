# Password Generator

A small Windows Forms tool for generating random passwords, with a few different generation
modes plus a "mangle" (leetspeak) transform for an existing password.

## Features

**Generate** creates a new password using whichever mode is checked:

| Mode | Description | Example |
| --- | --- | --- |
| *(none checked)* | Office-365-style: 4 letters + 4 digits | `Mune2297` |
| Increased complexity | 8 letters + 6 digits | `Dusesoqo468954` |
| Use Dictionary *(on by default)* | Two common English words (4-6 letters) + 2 digits | `ObjectClosed72` |
| More random | Fully randomized letters/digits, 8 characters | `iiIi3duE` |
| More random + Increased complexity | Fully randomized, 12 characters | `LEAVM10BiEnQ` |

- **Include special character** appends one special character (`!@#$%^&*()?`) to whichever
  password was just generated.
- **Mangle** applies a leetspeak-style substitution (`a`→`@`, `e`→`3`, `i`→`1`, `s`→`$`, `o`→`0`)
  to the password currently shown, one letter category per click — click again to mangle
  further.
- **Copy to clipboard** copies the current password.

Dictionary-mode words come from a filtered common-words list with profanity, insults, and
violence/religion-related terms removed. Passwords are generated with a cryptographically
secure random number generator (`RNGCryptoServiceProvider`), not `System.Random`.

## Requirements

- Windows
- .NET Framework 4.8

## Installing

Run `setup.exe` from the `publish` folder.

## Building from source

Open `PasswordGenerator.sln` in Visual Studio (2019+) and build. The word list used by "Use
Dictionary" (`4000-most-common-english-words-csv.csv`) needs to sit next to the built `.exe` —
the project's `Content` item already copies it to the output directory on build.
