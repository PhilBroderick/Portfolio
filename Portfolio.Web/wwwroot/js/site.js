// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
let currentEmail = "";
// invalidate subscribe email input
InvalidateInput = (message) => {
    let input = document.getElementById('email');
    input.classList.add('invalid');
    
    currentEmail = input.value;

    let parent = input.parentElement;

    let div = document.createElement('div')
    div.classList.add('validation-message');
    div.innerText = message;
    
    parent.appendChild(div);
    
    let submitBtn = document.getElementById('submit');
    submitBtn.disabled = true;


    input.addEventListener('change', (event) => {
        let val = event.target.value;
        if (currentEmail !== val) {
            submitBtn.disabled = false;
            input.classList.remove('invalid');
            div.hidden = true;
        }
        else {
            submitBtn.true = false;
            input.classList.add('invalid');
            div.hidden = false;
        }
    });
}

SuccessSubscribeMessage = (message) => {
    let messageP = document.createElement('p');
    messageP.innerText = message;
    messageP.classList.add('subscribe-success');
    
    messageP.animate({
        opacity: 0
    }, {
        duration: 3000,
        easing: "ease-in-out",
        iterations: 1,
        fill: "both"
    })
    .onfinish = () => {
        messageP.remove();   
    }
    
    document.getElementsByClassName('subscribe-form-container')[0].appendChild(messageP);
}