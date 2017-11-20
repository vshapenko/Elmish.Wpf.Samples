namespace TodoList

open System
open Elmish
open Elmish.WPF

module Models =
    type Priority =
        | Low
        | Medium
        | High

    type Item = 
        { Name: string; priority: Priority }

    type Model = { Title: string; Items: Item list }

    type Msg =
        | Add of Item
        | Remove of Item
        | Update of oldItem: Item * newItem: Item

module State = 
    open Models

    let init() = { Title= ""; Items= list.Empty }

    let update (msg:Msg) (model:Model) =
        match msg with
        | Add item -> { model with Items = item :: model.Items }
        | Remove item -> model
        | Update (oldItem, newItem) -> model

    let view _ _ = 
        [ "Add" |> Binding.cmd (fun _ m -> Add { Name = "test"; priority=Priority.Medium })
          "Remove" |> Binding.cmd (fun _ m -> Remove { Name = "test"; priority=Priority.Medium } ) ]

module App =
    open State

    [<EntryPoint;STAThread>]
    let main argv = 
        Program.mkSimple init update view
        |> Program.runWindow (TodoList.Views.MainWindow())