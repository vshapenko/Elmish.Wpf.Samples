// include Fake lib
#r @"packages\FAKE\tools\FakeLib.dll"
open Fake

let buildDir = "./build/"

Target "Build" (fun _ ->
  !! "All.sln"
      |> MSBuildRelease buildDir "Build"
      |> Log "Build-Output: "
)

Target "Clean" (fun _ ->
    CleanDir buildDir
)

Target "All" DoNothing

// dependencies
"Clean"
  ==> "Build"
  ==> "All"

// start build
RunTargetOrDefault "All"