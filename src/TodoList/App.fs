module App
    open System
    open Elmish
    open Elmish.WPF
    open FsXaml

    type MainWindow = XAML<"MainWindow.xaml">

    [<EntryPoint;STAThread>]
    let main argv = 
        Program.mkSimple TodoList.init TodoList.update TodoList.view
        |> Program.runWindow (MainWindow())