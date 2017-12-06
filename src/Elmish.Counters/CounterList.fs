module CounterList

    open FsXaml
    open Elmish.WPF
    open System.Collections.ObjectModel

    type View = XAML<"CounterList.xaml">

    type Model = ObservableCollection<Counter.Model>

    type Msg = 
    | Insert
    | Remove
    | Modify of int * Counter.Msg

    let init() = 
        ObservableCollection<Counter.Model>([ Counter.init() ])

    let update (msg:Msg) (model:Model) =
        match msg with
        | Insert ->
            model.Add(Counter.init()) |> ignore
            model
        | Remove ->
            match model.Count with
            | 0 -> model
            | count -> 
                model.RemoveAt(count - 1) |> ignore
                model
        | Modify (pos, counterMsg) ->
            model
            (* TODO
            |> List.mapi (fun i counterModel ->
                if i = pos then
                    Counter.update counterMsg counterModel
                else
                    counterModel)
            *)

    let view = 
        let xaml = View()
        // TODO xaml.Counters.Children.Add(Counter.view) |> ignore
        xaml

    let binding _ _ = 
        [   "Insert" |> Binding.cmd (fun _ m -> Insert)
            "Remove" |> Binding.cmd (fun _ m -> Remove)]