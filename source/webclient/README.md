# XPower WebClient

- Architechure: SmartPhone(Arm)
- OperativSystem: Crossplatform
- Language: TypeScript
- Type: Progressive Web App
- Dependencies: `nodejs npm`


## Setup

- Install: `npm cache verify && npm install -g @angular/cli@latest`
- New Angular app: `ng new AngularApp`
- Localhost development dependencies: `npm install http-server --save-dev`
- Add PWA Service Worker `ng add @angular/pwa --project AngularApp && ng build`
- run Debug: `ng build && ng serve`
- run Live: `ng build && npx http-server -p 8080 -c-1 dist/xpower-web-client`

## Directory Structure
```
../README.md        This file.
.vscode/            Editor Extensions
dist/               Distribution folder (shipped)
node_modules/       Application Dependencies
src/                Source root
package.json        Node packages
angular.json        Angular configuration file
ngsw-config.json    Angular Service Worker configuration file
```