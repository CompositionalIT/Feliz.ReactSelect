// Learn more about F# at http://fsharp.org
module Feliz.ReactSelect

open Fable.Core
open Fable.Core.JsInterop
open Feliz

let select: obj = importDefault "react-select"

type Choice = { Value: string; Label: string }
type GroupedChoice = { Label: string; Options: Choice array}

type MenuPlacement =
    | Auto
    | Bottom
    | Top
        member this.Value =
            match this with
            | Auto -> "auto"
            | Bottom -> "bottom"
            | Top -> "top"

type IReactSelectProperty = interface end

let (=>) key value = unbox<IReactSelectProperty>(key, value)

let lowerFieldNames choices = choices |> Array.map (fun option -> {| value = option.Value; label = option.Label|})

let lowerGroupedFieldNames opts =
    opts
    |> Array.map (fun gOpt ->
        {| label = gOpt.Label; options = gOpt.Options |> lowerFieldNames |})

[<Erase>]
type ReactSelect =

    static member inline autoFocus (isOn: bool) = "autoFocus" => isOn
    static member inline isDisabled (isOn: bool) = "isDisabled" => isOn
    static member inline isMulti (isOn: bool) = "isMulti" => isOn
    static member inline isClearable (isOn: bool) = "isClearable" => isOn
    static member inline isLoading (isOn: bool) = "isLoading" => isOn
    static member inline isRtl (isOn: bool) = "isRtl" => isOn
    static member inline isSearchable (isOn: bool) = "isSearchable" => isOn
    static member inline menuIsOpen (isOn: bool) = "menuIsOpen" => isOn
    static member inline closeMenuOnSelect (isOn: bool) = "closeMenuOnSelect" => isOn
    static member inline tabSelectsValue (isOn: bool) = "tabSelectsValue" => isOn
    static member inline backspaceRemovesValue (isOn: bool) = "backspaceRemovesValue" => isOn
    static member inline closeMenuOnScroll (close: bool) = "closeMenuOnScroll" => close
    static member inline hideSelectedOptions (isOn: bool) = "hideSelectedOptions" => isOn
    static member inline isFocused (isOn: bool) = "isFocused" => isOn
    static member inline escapeClearsValue (isOn: bool) = "escapeClearsValue" => isOn

    static member inline pageSize (numberOfOptions: int) = "pageSize" => numberOfOptions
    static member inline minMenuHeight (defaultValue: int) = "minMenuHeight" => defaultValue
    static member inline maxMenuHeight (defaultValue: int) = "maxMenuHeight" => defaultValue

    static member inline defaultInputValue (inputVal: string) = "defaultInputValue" => inputVal
    static member inline inputValue (inputVal: string) = "inputValue" => inputVal
    static member inline name (defaultValue: string) = "name" => defaultValue
    static member inline customClass (className: string) = "className" => className
    static member inline classNamePrefix (prefix: string) = "classNamePrefix" => prefix
    static member inline placeholder (defaultValue: string) = "placeholder" => defaultValue
    static member inline noOptionsMessage (defaultValue: string) = "noOptionsMessage" => defaultValue

    static member inline defaultValue (initialVal: Choice) =
        "defaultValue" => {| value = initialVal.Value; label = initialVal.Label|}

    static member inline defaultValue (selected: Choice array) =
        "defaultValue" => (lowerFieldNames selected)

    static member inline menuPlacement (placement: MenuPlacement) = "menuPlacement" => placement.Value

    static member inline onChange (options: Choice array -> unit) = "onChange" => options

    static member inline onChange (options: GroupedChoice array -> unit) = "onChange" => options

    static member inline options (choices: Choice array) =
        "options" => (lowerFieldNames choices)

    static member inline options (choices: GroupedChoice array) =
        "options" => (lowerGroupedFieldNames choices)

    static member inline create (props: IReactSelectProperty list) = Interop.reactApi.createElement (select, createObj !!props)