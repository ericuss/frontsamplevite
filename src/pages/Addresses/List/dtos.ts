export interface Response {
    info: Info
    results: Location[]
}

export interface Info {
    count: number
    pages: number
    next: string
    prev: any
}

export interface Location {
    id: string
    name: string
    type: string
    dimension: string
    residents: string[]
    url: string
    created: string
}