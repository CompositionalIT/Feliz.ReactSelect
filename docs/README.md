# Feliz.ReactSelect demo

## Running locally

One time:

```bash
npm install
```

Every time:

```bash
npm start
```

This will:

- Compile the F# code into JavaScript code
- Start a dev server hosting the app at http://localhost:8080

## Deploying a new version of the demo site

- Change the reference to the src project into a reference to the appropriate NuGet package. For example:

  ```diff
      </ItemGroup>
  -   <ItemGroup>
  -       <ProjectReference Include="../../fable/Feliz.ReactSelect/Feliz.ReactSelect.fsproj" />
  -   </ItemGroup>
      <ItemGroup>
  +       <PackageReference Include="Feliz.ReactSelect" Version="0.0.6" />
  ```

- Run `npm run publish-docs`
