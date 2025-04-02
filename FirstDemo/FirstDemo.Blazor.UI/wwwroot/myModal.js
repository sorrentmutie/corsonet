var myModal;

export function mostraModale(id) {
    myModal = new bootstrap.Modal(document.getElementById(id));
    myModal.show();
}

export function chiudiModale() {
    if (myModal) {
        myModal.hide();
    };
}