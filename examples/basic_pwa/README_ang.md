# Angular PWA Example

dependencies: `nodejs npm`
install: `npm cache verify && npm install -g @angular/cli@latest`
new app: `ng new AngularApp`
localhost dependencies: `npm install http-server --save-dev`
add PWA service Worker `ng add @angular/pwa --project AngularApp && ng build`
run : `npx http-server -p 8080 -c-1 dist/angular-app`