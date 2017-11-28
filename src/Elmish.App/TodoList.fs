﻿namespace TodoList

open FsXaml
open Elmish.WPF

type View = XAML<"TodoList.xaml">

type Priority =
    | Low
    | Medium
    | High

type Item = 
    { Description: string; Priority: Priority; Completed: bool }

type Model = { Title: string; Items: Item list }

type Msg =
    | Add of Item
    | Remove of Item
    | Update of oldItem: Item * newItem: Item

module Elm =
    let init() = { 
        Title = "" 
        Items = 
            [ { Description = "Task 1"; Priority = Priority.Low; Completed = false }
              { Description = "Task 2"; Priority = Priority.Medium; Completed = true }
              { Description = "Task 3"; Priority = Priority.High; Completed = true } ]
    }

    let update (msg:Msg) (model:Model) =
        match msg with
        | Add item -> { model with Items = item :: model.Items }
        | Remove item -> model
        | Update (oldItem, newItem) -> model
    
    let view _ _ = 
        [ "Add" |> Binding.cmd (fun _ m -> Add { Description = "test"; Priority=Priority.Medium; Completed = false })
          "Remove" |> Binding.cmd (fun _ m -> Remove { Description = "test"; Priority=Priority.Medium; Completed = false } ) 
          "Items" |> Binding.oneWay (fun m -> m.Items)]