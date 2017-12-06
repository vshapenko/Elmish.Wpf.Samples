module App
    open System
    open Elmish
    open Elmish.WPF
    open FsXaml

    type MainWindow = XAML<"MainWindow.xaml">

    [<EntryPoint;STAThread>]
    let main argv = 
        let window = MainWindow();
        window.MainContainer.Children.Add(Counter.view) |> ignore

        Program.mkSimple Counter.init Counter.update Counter.binding
        |> Program.runWindow(window)