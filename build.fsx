// include Fake lib
#r @"packages\FAKE\tools\FakeLib.dll"
open Fake

let buildDir = "./build/"

Target "Debug" (fun _ ->
  !! "All.sln"
      |> MSBuildDebug (buildDir + "debug") "Build"
      |> Log "Build-Output: "
)

Target "Clean" (fun _ ->
    CleanDir buildDir
)

// dependencies
"Clean"
  ==> "Debug"

// start build
RunTargetOrDefault "Debug"