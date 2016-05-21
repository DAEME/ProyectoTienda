 
/**
   Copyright 2011 Couchbase, Inc.

   Licensed under the Apache License, Version 2.0 (the "License");
   you may not use this file except in compliance with the License.
   You may obtain a copy of the License at

       http://www.apache.org/licenses/LICENSE-2.0

   Unless required by applicable law or agreed to in writing, software
   distributed under the License is distributed on an "AS IS" BASIS,
   WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
   See the License for the specific language governing permissions and
   limitations under the License.
**/
/**
 * @author Benjamin Young <byoung@bigbluehat.com>
 *
 * Original code came from:
 * @link http://jqueryui.com/demos/autocomplete/#combobox
 **/

/* Jose Caycho Garcia*/


(function ($) {
  /**
   * Combobox widget
   * @link http://jqueryui.com/demos/autocomplete/#combobox
   */
    
        $.widget("ui.combobox", {
            //version: "1.9.2",
            options: {
                tip: "",
                isReadonly: false,
                
                /**
                 * This event fire after selected select.
                 */
                onChange: function (option) { }
              
               

            },
            input: null,
            _create: function () {
                var that = this,
                select = this.element.hide(),
                id = this.element.attr('id'),
                selected = select.children(":selected"),
                value = selected.val() ? selected.text() : "",
                wrapper = this.wrapper = $("<span>")
                    .addClass("ui-combobox")
                    .insertAfter(select);

                function removeIfInvalid(element) {

                    
                    var value = $(element).val(),
                        matcher = new RegExp("^" + $.ui.autocomplete.escapeRegex(value) + "$", "i"),
                        valid = false;
                    
                    select.children("option").each(function () {
                        if ($(this).text().match(matcher)) {
                            this.selected = valid = true;
                            return false;
                        }
                    });
             
                   
                    if (!valid) {
                        // remove invalid value, as it didn't match anything
                   
                        $(element)
                            .val("")
                            .attr("title", value + " No coinciden con los resultados!")
                            .tooltip("open");
                         
                        select.val("");
                        setTimeout(function () {
                            input.tooltip("close").attr("title", "");
                        }, 2500);
                        input.data("autocomplete").term = "";
                        
                        return false;
                    }
                 
                }
                
               
                input = $("<input>")
                    .appendTo(wrapper)
                    .val(value)
                    .attr("title", "")
    //				.addClass( "ui-state-default ui-combobox-input" )
                    .addClass("ui-combobox-input form-control input-sm txtLetra cbo")
                    .attr('id', id + '_')
                    .autocomplete({
                        delay: 0,
                        minLength: 1,
                        source: function (request, response) {
                            var matcher = new RegExp($.ui.autocomplete.escapeRegex(request.term), "i");
                            response(select.children("option").map(function () {
                                var text = $(this).text();
                                if (this.value && (!request.term || matcher.test(text)))
                                    return {
                                        label: text.replace(
                                            new RegExp(                                             
                                                $.ui.autocomplete.escapeRegex(request.term) 
                                                
                                            ), ""),
                                        value: text,
                                        option: this
                                    };
                            }));
                        },
                        select: function (event, ui) {
                            ui.item.option.selected = true;
                            that._trigger("selected", event, {
                                item: ui.item.option
                            });
                            that.options.onChange(ui.item.option);
                             
                        },
                        change: function (event, ui) {
                            if (!ui.item)
                                return removeIfInvalid(this);
                        } 
                    })
                    .keypress(function (e) {
                        if (e.keyCode === 13) {

                            if (input.autocomplete("widget").is(":visible")) {
                               input.autocomplete("close");
                               removeIfInvalid(input);
                               return;
                            }

                            $(this).blur();

                             
                             
                        }
                    })
                    .change(function () { 
                        $(this).blur();
                    })
                    .addClass("ui-widget ui-widget-content ui-corner-left");

              

                input.data("autocomplete")._renderItem = function (ul, item) {
                    return $("<li>")
                            .data("item.autocomplete", item)
                            .append("<a>" + item.label + "</a>")
                            .appendTo(ul);

                };

               
    //            $("<a>")
    //                .attr("tabIndex", -1)
    //                .attr("title", this.options.tip)
    //                .tooltip()
    //                .appendTo(wrapper)
    //                .button({
    //                    icons: {
    //                        primary: "ui-icon-triangle-1-s"
    //                    },
    //                    text: false
    //                })
    //                //Eliminar
    ////				.removeClass( "ui-button" )
    //                .removeClass("ui-corner-all")
    //                .addClass("ui-corner-right ui-combobox-toggle btn btn-primary")
    //                .click(function () {
    //                    // close if already visible
    //                    if (input.autocomplete("widget").is(":visible")) {
    //                        input.autocomplete("close");
    //                        removeIfInvalid(input);
    //                        return;
    //                    }

    //                    // work around a bug (likely same cause as #5265)
    //                    $(this).blur();

    //                    // pass empty string as value to search for, displaying all results
    //                    input.autocomplete("search", "");
    //                    input.focus();
    //                });

                input
                    .tooltip({
                        position: {
                            of: this.button
                        },
                        tooltipClass: "ui-state-highlight"
                    });

                if (this.options.isReadonly) {
                    input.attr('readonly', true);
                    
                }
            },

            destroy: function () {
                this.wrapper.remove();
                this.element.show();
                $.Widget.prototype.destroy.call(this);
                 
            },
             
            setSelect: function (value, text) {
                input.val(text);
                
                 
            }
        });
     
})(jQuery);



 