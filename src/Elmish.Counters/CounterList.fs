module CounterList

    open FsXaml
    open Elmish.WPF

    type View = XAML<"CounterList.xaml">

    type Model = Counter.Model list

    type Msg = 
    | Insert
    | Remove
    | Modify of int * Counter.Msg

    let init() : Model =
        [ Counter.init() ]

    let update (msg:Msg) (model:Model) =
        match msg with
        | Insert ->
            Counter.init() :: model // append to list
        | Remove ->
            match model with
            | [] -> []              // list is already empty
            | x :: rest -> rest     // remove from list
        | Modify (pos, counterMsg) ->
            model
            |> List.mapi (fun i counterModel ->
                if i = pos then
                    Counter.update counterMsg counterModel
                else
                    counterModel)

(*
    let view = 
        let (counterBinding, counterView) = Counter.view

        let binding _ _ = 
            [ "Insert" |> Binding.cmd (fun _ m -> Insert)
              "Remove" |> Binding.cmd (fun _ m -> Remove)]

        (binding, View)
*)