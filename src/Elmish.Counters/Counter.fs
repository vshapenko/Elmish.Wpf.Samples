module Counter

    open FsXaml
    open Elmish.WPF

    type View = XAML<"Counter.xaml">

    type Model = { Count: int }

    type Msg =
    | Increment
    | Decrement

    let init() : Model = { Count = 0 }

    let update (msg:Msg) (model:Model) : Model =
        match msg with
        | Increment -> { model with Count = model.Count + 1 }
        | Decrement -> { model with Count = model.Count - 1 }
    
    let binding _ _ = 
        [   "Count" |> Binding.oneWay (fun m -> m.Count)
            "Increment" |> Binding.cmd (fun _ m -> Increment)
            "Decrement" |> Binding.cmd (fun _ m -> Decrement) ]

    let view = new View()