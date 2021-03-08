module Index

open Elmish
open Feliz.MultiSelect

type Model =
    { SelectedOptions: Choice array }

type Msg =
    | SetSelectedOption of Choice array
    | ClearOptions


let init(): Model * Cmd<Msg> =
    let model =
        { SelectedOptions =  Array.empty }
    model, Cmd.none

let update (msg: Msg) (model: Model): Model * Cmd<Msg> =
    match msg with
    | SetSelectedOption fields ->
        { SelectedOptions = fields    }, Cmd.none
    | ClearOptions -> { SelectedOptions = Array.empty }, Cmd.none

open Fable.React
open Fable.React.Props
open Fulma


let citOptions =
    [|
        { Value = "Isaac"; Label = "Isaac" }
        { Value = "Ryan";  Label = "Ryan"  }
        { Value = "Prash"; Label = "Prash" }
        { Value = "Akash"; Label = "Kash"  }
    |]

let sdiOptions =
    [|
        { Value = "Ben"; Label = "Ben"  }
        { Value = "Rick"; Label = "Rick" }
    |]

let groupedOptions =
    [|
        {Label = "CIT"; Options = citOptions }
        {Label = "SDI"; Options = sdiOptions }
    |]

let view (model : Model) (dispatch : Msg -> unit) =
    Hero.hero [
        Hero.Color IsPrimary
        Hero.IsFullHeight
        Hero.Props [
            Style [
                Background """linear-gradient(rgba(0, 0, 0, 0.5), rgba(0, 0, 0, 0.5)), url("https://unsplash.it/1200/900?random") no-repeat center center fixed"""
                BackgroundSize "cover"
            ]
        ]
    ] [

        Hero.body [ ] [
            Container.container [ ] [
                MultiSelect.create [
                        MultiSelect.onChange (SetSelectedOption >> dispatch)
                        MultiSelect.options (SingleChoices citOptions)
                        MultiSelect.isMulti false
                        MultiSelect.isClearable true
                        MultiSelect.isSearchable true
                        // MultiSelect.inputValue "HIHIHI"
                        // MultiSelect.tabSelectsValue true
                        // MultiSelect.autoFocus true
                        // MultiSelect.backspaceRemovesValue true
                        // MultiSelect.isRtl true
                        // MultiSelect.isLoading true
                        // MultiSelect.menuIsOpen true
                        // MultiSelect.menuPlacement MenuPlacement.Top
                        // MultiSelect.defaultInputValue "Kash"
                        // MultiSelect.defaultValue (MultipleValues citOptions.[0..1])
                ]



            ]
        ]
    ]
