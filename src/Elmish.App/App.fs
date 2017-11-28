namespace Elmish.App

module App =
    open System
    open Elmish
    open Elmish.WPF
    open FsXaml

    type MainWindow = XAML<"MainWindow.xaml">

    [<EntryPoint;STAThread>]
    let main argv = 
        Program.mkSimple TodoList.Elm.init TodoList.Elm.update TodoList.Elm.view
        |> Program.runWindow (MainWindow())