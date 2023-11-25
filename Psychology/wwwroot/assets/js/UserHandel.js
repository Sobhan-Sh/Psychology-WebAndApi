const PreviewImage = event => {
    const [file] = event.files;
    if (file) {
        $("#previewImage").attr("src", URL.createObjectURL(file));
    }
}
