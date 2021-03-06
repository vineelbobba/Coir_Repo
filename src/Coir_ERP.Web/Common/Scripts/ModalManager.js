import { date } from "gulp-util";

var app = app || {};

(function ($) {
    var _loadedScripts = [];

    app.modals = app.modals || {};

    app.ModalManager = (function () {
        var _normalizeOptions = function (options) {
            if (!options.moalId) {
                options.modalId = 'Modal_' + ((Math.floor(Math.random() * 1000000))) + new date().getTime();
            }

        }

        function _removeContainer(modalId) {
            var _containerId = modalId + 'Container';
            var _containerSelector = '#' + _containerId;

            var $container = $(_containerSelector);
            if ($container.length) {
                $container.remove();
            }
        };

        function _createContainer(modalId) {
            _removeContainer(modalId);

            var _containerId = modalId + 'Container';
            return $('<div id="' + _containerId + '"></div>')
                .append(
                    '<div id="' + modalId + '" class="modal fade" tabindex="-1" role ="modal" aria-hidden="true">' +
                    '<div class="modal-dialog modal-md">' +
                    '<div class="modal-content"></div>' +
                    '</div>' +
                    '</div>'
                ).appendTo('body');
        }

        return function (options) {

            _normalizeOptions(options);

            var _options = options;
            var _$modal = null;
            var _modalId = options.modalId;
            var _modalSelector = '#' + _modalId;
            var _modalObject = null;

            var _publicApi = null;
            var _args = null;
            var _getResultCallBack = null;

            var _onCloseCallBacks = [];
            var _isSaveTriggered = true;

            function _saveModal(isSaveNew) {
                if (_modalObject && _modalObject.save && _isSaveTriggered) {

                    _modalObject.save(isSaveNew);
                }
            }

            function _initAndShowModal() {

                _$modal = $(_modalSelector);

                _$modal.modal({
                    backdrop: 'static'
                });

                _$modal.on('hidden.bs.modal', function () {
                    _removeContainer(_modalId);

                    for (var i = 0; i < _onCloseCallBacks.length; i++) {
                        _onCloseCallBacks[i]();
                    }
                });

                _$modal.on('shown.bs.modal', function () {
                    if (!_options.viewOnlyMode) {
                        if (_$modal.find('input[type=text]:not([type=hidden]):first').val() == "")
                            _$modal.find('input[type=text]:not([type=hidden]):first').focus();
                    }
                });

                var modalClass = app.modals[options.modalClass];
                if (modalClass) {
                    _modalObject = new modalClass();
                    if (_modalObject.init) {
                        _modalObject.init(_publicApi, args);
                    }
                }

                _$modal.find('.save-new-button').click(function () {
                    _saveModal(true);
                });

                _$modal.keydown(function (e) {
                    if (e.which == 13) {
                        if ($(e.target).hasClass('save-button')) {
                            _saveModal(false);
                        }
                        if ($(e.target).hasClass('close-button')) {
                            _$modal.modal('hide');
                            $('.modal-backdrop').hide();
                        }
                        if ($(e.target).hasClass('save-new-button')) {
                            _saveModal(true);
                        }
                    }

                });

                if (options.viewOnlyMode) {
                    if (_modalObject && _modalObject.SetViewOnlyMode) {
                        _modalObject.SetViewOnlyMode();
                    }

                }
                _$modal.modal('show');
                app.utils.setBusy($('body'), false);
            };

            var _open = function (args, getResultCallBack) {
                app.utils.setBusy($('body'), true);
                _isSaveTriggered = true;
                _args = args || {};
                _getResultCallBack = getResultCallBack;
                _createContainer(_modalId)
                    .find('.modal-content')
                    .load(options.viewUrl, _args, function (response, status, xhr) {
                        if (status == "error") {
                            app.utils.setBusy($('body'), false);
                            abp.message.warn(abp.localization.abpWeb('InternalServerError'));
                            return;
                        };
                        _loadedScripts = [];
                        if (options.scriptUrl && _.indexOf(_loadedScripts, options.scriptUrl) < 0) {
                            $.getScript(options.scriptUrl)
                                .done(function (script, textStatus) {
                                    _loadedScripts.push(options.scriptUrl);
                                    _initAndShowModal();
                                })
                                .fail(function (jqxhr, settings, exception) {
                                    app.utils.setBusy($('body'), false);
                                    abp.message.warn(abp.localization.abpWeb('InternalServerError'));
                                });
                        }
                        else {
                            _initAndShowModal();
                        }
                    });
            };

            var _close = function () {
                if (!_$modal) {
                    return;
                }
                _$modal.modal('hide');
                $('.modal-backdrop').hide();
            };

            var _onClose = function (onCloseCallBack) {
                _onCloseCallBacks.push(onCloseCallBack);
            }

            function _setBusy(isBusy) {
                if (isBusy)
                    _isSaveTriggered = false;
                else
                    _isSaveTriggered = true;

                if (!_$modal) {
                    return;
                }
                _$modal.find('.modal-footer button').buttonBusy(isBusy);
            }

            function _enableSave() {
                _isSaveTriggered = true;
                _$modal.find('.modal-footer button').buttonBusy(false);
            }

            function _setUnobtrusive(_$form) {
                if (!_$form.data('unobtrusiveValidation')) {
                    $.validator.unobtrusive.parse(_$form);
                    _$form.data('unobtrusiveValidation').validate({ ignore: "" });
                }
            }

            _publicApi = {
                open: _open,
                reopen: function () {
                    _open(_args);
                },

                close=_close,
                getModalId: function () {
                    return _modalId;
                },
                getModal: function () {
                    return _$modal;
                },
                getArgs: function () {
                    return _args;
                },
                getOptions: function () {
                    return _options;
                },
                setBusy: _setBusy,

                enableSave: _enableSave,
                getResultCallBack: function () {
                    return _getResultCallBack;
                },
                setUnobtrusive: function (_$form) { _setUnobtrusive(_$form) },

                setResult: function () {
                    _getResultCallBack && _getResultCallBack.apply(_publicApi, arguments);
                },

                onClose: _onClose
            }

            return _publicApi;
        };
    })();


})(jQuery);