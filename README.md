# Feliz.ReactSelect

Feliz style bindings for [react-select](https://react-select.com/home). The [full props list](https://react-select.com/props) is available at the react-select docs site.

## Source code

Found in `./src/`

## Demo

Code demonstrating using Feliz.React select from a Feliz app is available in `./demo`. [./demo/README.md](./demo/README.md) includes instructions on how to run the app locally and how to publish a new version of the demo site.

You can see the demo running live at [https://compositionalit.github.io/MultiSelect/](https://compositionalit.github.io/MultiSelect/).

## Publishing a new package

- Make changes in `./src/`
- Change the version in `./src/Feliz.ReactSelect.fsproj`
- Push to GitHub
- Wait for PR to be merged
- Wait for the GitHub action (configured in `./github/workflows/publish.yml`) to finish
- Tag the commit on main
- Publish the demo site targeting the new version of the NuGet package
