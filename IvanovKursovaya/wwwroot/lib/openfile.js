window.BlazorDownloadFile = (filename, contentType, data) => {
    const blob = new Blob([new Uint8Array(data)], { type: contentType });
    const url = URL.createObjectURL(blob);
    const a = document.createElement('a');
    a.href = url;
    a.download = filename;
    a.click();
    URL.revokeObjectURL(url);
};
