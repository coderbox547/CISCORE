# Static Assets

Copy the following folders from the original project's `cis/Content/` into this `wwwroot/` directory:

| Source (cis/Content/) | Destination (wwwroot/) |
|-----------------------|------------------------|
| css/                  | css/                   |
| js/                   | js/                    |
| images/               | images/                |
| fonts/                | fonts/                 |

Also copy `cis/fonts/` (glyphicons) into `wwwroot/fonts/`.

Example commands:
```
cp -r cis/Content/css/*     CisCore/wwwroot/css/
cp -r cis/Content/js/*      CisCore/wwwroot/js/
cp -r cis/Content/images/*  CisCore/wwwroot/images/
cp -r cis/Content/fonts/*   CisCore/wwwroot/fonts/
cp -r cis/fonts/*           CisCore/wwwroot/fonts/
```
