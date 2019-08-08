## For inner loop development

  1. Open this folder in VsCode
  2. Fetch node packages
```bash
npm install
```
Next:

  - To Compile TypeScript to JavaScript:
```bash
npm run compile # calls `tsc -p ./` (as defined in package.json)
```
  - To Create .vsix package (note that this alone won't include DScrip language server binaries):
```bash
npm run package # calls `vsce package` (as defined in package.json)
```
  - To debug the extension with VsCode: 
    - Choose `Debug` -> `Start Debugging` from VsCode

## When building with BuildXL

Our current BuildXL build **DOES NOT** automatically
  1. fetch node packages (`npm install`), nor does it
  2. compile TypeScript to JavaScript (`tsc -p ./`).  
  
Instead, it expects the content of the `./node_modules` and `./out` folders to be 