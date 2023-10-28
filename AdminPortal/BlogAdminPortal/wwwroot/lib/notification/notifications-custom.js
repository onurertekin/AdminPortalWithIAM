function notify(title, message, theme, duration) {

    if (!duration)
        duration = 5000;

    var myNotification = window.createNotification({

        closeOnClick: true,
        displayCloseButton: false,
        positionClass: 'nfc-top-right',
        onclick: false,
        showDuration: duration,
        theme: theme // success, info, warning, error, and none
    });

    myNotification({
        //title: commonLocalization[title][currentLanguageCode],
        title: title,
        message: message
    });
}