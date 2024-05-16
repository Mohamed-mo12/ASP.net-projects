$.validator.addMethod('filesize', function (value, element, param) {
    return this.optional(element) || (element.files[0].size <= param);
}, 'Max file size must be 1MB.');

$.validator.messages.filesize = 'Max file size must be 1MB.';