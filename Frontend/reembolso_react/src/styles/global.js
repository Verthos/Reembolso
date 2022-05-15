import { createGlobalStyle } from "styled-components";
export const GlobalStyle = createGlobalStyle`

:root {
    --background: #c5e4e7;

    --strong-cyan: #26c0ab; //Selected and reset buttons, h1 in the result component
    --darker-cyan: #00494d; //non-selected bottom
    --grayish-cyan-500: #5e7a7d; //font-color in h3 and custom buttom 
    --grayish-cyan-450: #7f9c9f; //font-color into dark components
    --grayish-cyan-200: #c5e4e7; //background
}




* { 
    margin:0;
    padding:0;
    box-sizing: border-box;
}

html {


    @media (max-width: 1080px) {
            font-size: 93.75%; //15px
        }
    @media (max-width: 720px) {
            font-size: 87.5%; //14px
        }
    @media (max-width: 340px) {
            font-size: 82.5%; 
        }
}


body {
    font-family: Space;
    width: calc(100vw - (100vw - 100%));
    background-color: var(--shape);
    -webkit-font-smoothing: antialiased;
}




h1, h2, h3, h4, h5, h6, strong {
    font-weight: 600;
}

button {
    cursor: pointer;
}

[disabled] {
    opacity: 0.6;
    cursor: not-allowed;
}

`