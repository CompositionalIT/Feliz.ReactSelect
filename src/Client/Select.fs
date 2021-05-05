module Feliz.MultiSelect

open Fable.Core
open Fable.Core.JsInterop
open Feliz

let select: obj = importDefault "react-select"

type Choice = { Value: string; Label: string }
type GroupedChoice = { Label: string; Options: Choice array}

type ChoiceType =
    | SingleChoices of Choice array
    | GroupedChoices of GroupedChoice array

type DefaultChoice =
    | SingleChoice of Choice
    | MultipleChoices of Choice array

type MenuPlacement =
    | Auto
    | Bottom
    | Top
        member this.Value =
            match this with
            | Auto -> "auto"
            | Bottom -> "bottom"
            | Top -> "top"

[<Erase>]
type MultiSelect =

    static member inline autoFocus (isOn: bool) = prop.custom("autoFocus", isOn)
    static member inline isDisabled (isOn: bool) = prop.custom("isDisabled", isOn)
    static member inline isMulti (isOn: bool) = prop.custom("isMulti", isOn)
    static member inline isClearable (isOn: bool) = prop.custom("isClearable", isOn)
    static member inline isLoading (isOn: bool) = prop.custom("isLoading", isOn)
    static member inline isRtl (isOn: bool) = prop.custom("isRtl", isOn)
    static member inline isSearchable (isOn: bool) = prop.custom("isSearchable", isOn)
    static member inline menuIsOpen (isOn: bool) = prop.custom("menuIsOpen", isOn)
    static member inline closeMenuOnSelect (isOn: bool) = prop.custom("closeMenuOnSelect", isOn)
    static member inline tabSelectsValue (isOn: bool) = prop.custom("tabSelectsValue", isOn)
    static member inline backspaceRemovesValue (isOn: bool) = prop.custom("backspaceRemovesValue", isOn)
    static member inline closeMenuOnScroll (close: bool) = prop.custom("closeMenuOnScroll", close)
    static member inline hideSelectedOptions (isOn: bool) = prop.custom("hideSelectedOptions", isOn)
    static member inline isFocused (isOn: bool) = prop.custom("isFocused", isOn)
    static member inline escapeClearsValue (isOn: bool) = prop.custom("escapeClearsValue", isOn)

    static member inline pageSize (numberOfOptions: int) = prop.custom("pageSize", numberOfOptions)
    static member inline minMenuHeight (defaultValue: int) = prop.custom("minMenuHeight ", defaultValue)
    static member inline maxMenuHeight (defaultValue: int) = prop.custom("maxMenuHeight ", defaultValue)

    static member inline defaultInputValue (inputVal: string) = prop.custom("defaultInputValue", inputVal)
    static member inline inputValue (inputVal: string) = prop.custom("inputValue", inputVal)
    static member inline name (defaultValue: string) = prop.custom("name", defaultValue)
    static member inline customClass (className: string) = prop.custom("className", className)
    static member inline classNamePrefix (prefix: string) = prop.custom("className", prefix)
    static member inline placeholder (defaultValue: string) = prop.custom("placeholder", defaultValue)
    static member inline noOptionsMessage (defaultValue: string) = prop.custom("noOptionsMessage ", defaultValue)

    static member inline defaultValue (initialVal: DefaultChoice) =
        match initialVal with
        | MultipleChoices options ->
            let lowerFieldNames = options |> Array.map (fun option -> {| value = option.Value; label = option.Label|})
            prop.custom("defaultValue", lowerFieldNames)
        | SingleChoice option ->
            prop.custom("defaultValue", {| value = option.Value; label = option.Label|})

    static member inline menuPlacement (placement: MenuPlacement) = prop.custom("menuPlacement", placement.Value)

    static member inline onChange (options:Choice array -> unit) = prop.custom("onChange", options)

    static member inline options (values: ChoiceType) =
        match values with
        | SingleChoices opts ->
            let lowerFieldNames = opts |> Array.map (fun option -> {| value = option.Value; label = option.Label|})
            prop.custom("options", lowerFieldNames)
        | GroupedChoices opts ->
            let lowerFieldNames = opts |> Array.map (fun gOpt -> {| label = gOpt.Label; options = gOpt.Options |> Array.map (fun option -> {| value = option.Value; label = option.Label|}) |})
            prop.custom("options", lowerFieldNames)



    static member inline create props = Interop.reactApi.createElement (select, createObj !!props)