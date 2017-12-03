module App
    open System
    open Elmish
    open Elmish.WPF
    open FsXaml

    type MainWindow = XAML<"MainWindow.xaml">

    [<EntryPoint;STAThread>]
    let main argv = 

        let (binding, view) = Counter.view

        let window = MainWindow();
        window.MainContainer.Children.Add(view()) |> ignore

        Program.mkSimple Counter.init Counter.update binding
        |> Program.runWindow(window)