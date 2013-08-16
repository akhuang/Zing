namespace Zing.Mvc
{
    using System;
    using System.ComponentModel;
    using System.Diagnostics;
    using System.Globalization;
    using System.Linq.Expressions;
    using System.Reflection;
    using System.Runtime.CompilerServices;
    using System.Web.Mvc;
    using JetBrains.Annotations;

    /// <summary>
    /// Defines class to fluently configure metadata.
    /// </summary>
    public class ModelMetadataItemBuilder<TValue> : IModelMetadataItemBuilder<TValue>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ModelMetadataItemBuilder{TValue}"/> class.
        /// </summary>
        /// <param name="item">The item.</param>
        public ModelMetadataItemBuilder([NotNull] ModelMetadataItem item)
        {
            //Invariant.IsNotNull(item, "item");

            Item = item;
        }

        /// <summary>
        /// Gets the internal item.
        /// </summary>
        /// <value>The item.</value>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public ModelMetadataItem Item
        {
            [EditorBrowsable(EditorBrowsableState.Never)]
            get;
            private set;
        }

        [NotNull]
        private ModelMetadataItemBuilder<TValue> This
        {
            [DebuggerStepThrough]
            get
            {
                return this;
            }
        }

        ModelMetadataItem IModelMetadataItemBuilder<TValue>.Item
        {
            get
            {
                return Item;
            }
        }

        [NotNull]
        IModelMetadataItemBuilder<TValue> IModelMetadataItemBuilder<TValue>.DisplayName(Func<string> value)
        {
            return DisplayName(value);
        }

        [NotNull]
        IModelMetadataItemBuilder<TValue> IModelMetadataItemBuilder<TValue>.ShortDisplayName(string value)
        {
            return ShortDisplayName(value);
        }

        [NotNull]
        IModelMetadataItemBuilder<TValue> IModelMetadataItemBuilder<TValue>.ShortDisplayName(Func<string> value)
        {
            return ShortDisplayName(value);
        }

        [NotNull]
        IModelMetadataItemBuilder<TValue> IModelMetadataItemBuilder<TValue>.Template(string value)
        {
            return Template(value);
        }

        [NotNull]
        IModelMetadataItemBuilder<TValue> IModelMetadataItemBuilder<TValue>.Description(string value)
        {
            return Description(value);
        }

        [NotNull]
        IModelMetadataItemBuilder<TValue> IModelMetadataItemBuilder<TValue>.Description(Func<string> value)
        {
            return Description(value);
        }

        [NotNull]
        IModelMetadataItemBuilder<TValue> IModelMetadataItemBuilder<TValue>.ReadOnly()
        {
            return ReadOnly();
        }

        [NotNull]
        IModelMetadataItemBuilder<TValue> IModelMetadataItemBuilder<TValue>.Writable()
        {
            return Writable();
        }

        [NotNull]
        IModelMetadataItemBuilder<TValue> IModelMetadataItemBuilder<TValue>.Compare(string otherProperty)
        {
            return Compare(otherProperty);
        }

        [NotNull]
        IModelMetadataItemBuilder<TValue> IModelMetadataItemBuilder<TValue>.Compare(string otherProperty, string errorMessage)
        {
            return Compare(otherProperty, errorMessage);
        }

        [NotNull]
        IModelMetadataItemBuilder<TValue> IModelMetadataItemBuilder<TValue>.Compare(string otherProperty, Func<string> errorMessage)
        {
            return Compare(otherProperty, errorMessage);
        }

        [NotNull]
        IModelMetadataItemBuilder<TValue> IModelMetadataItemBuilder<TValue>.Compare(string otherProperty, Type errorMessageResourceType, string errorMessageResourceName)
        {
            return Compare(otherProperty, errorMessageResourceType, errorMessageResourceName);
        }

        [NotNull]
        IModelMetadataItemBuilder<TValue> IModelMetadataItemBuilder<TValue>.Required()
        {
            return Required();
        }

        [NotNull]
        IModelMetadataItemBuilder<TValue> IModelMetadataItemBuilder<TValue>.Required(string errorMessage)
        {
            return Required(errorMessage);
        }

        [NotNull]
        IModelMetadataItemBuilder<TValue> IModelMetadataItemBuilder<TValue>.Required(Func<string> errorMessage)
        {
            return Required(errorMessage);
        }

        [NotNull]
        IModelMetadataItemBuilder<TValue> IModelMetadataItemBuilder<TValue>.Required(Type errorMessageResourceType, string errorMessageResourceName)
        {
            return Required(errorMessageResourceType, errorMessageResourceName);
        }

        [NotNull]
        IModelMetadataItemBuilder<TValue> IModelMetadataItemBuilder<TValue>.Optional()
        {
            return Optional();
        }

        [NotNull]
        IModelMetadataItemBuilder<TValue> IModelMetadataItemBuilder<TValue>.AsHidden()
        {
            return AsHidden();
        }

        [NotNull]
        IModelMetadataItemBuilder<TValue> IModelMetadataItemBuilder<TValue>.AsHidden(bool hideSurroundingHtml)
        {
            return AsHidden(hideSurroundingHtml);
        }

        [NotNull]
        IModelMetadataItemBuilder<TValue> IModelMetadataItemBuilder<TValue>.HideSurroundingHtml()
        {
            return HideSurroundingHtml();
        }

        [NotNull]
        IModelMetadataItemBuilder<TValue> IModelMetadataItemBuilder<TValue>.ShowSurroundingHtml()
        {
            return ShowSurroundingHtml();
        }

        [NotNull]
        IModelMetadataItemBuilder<TValue> IModelMetadataItemBuilder<TValue>.AllowHtml()
        {
            return AllowHtml();
        }

        [NotNull]
        IModelMetadataItemBuilder<TValue> IModelMetadataItemBuilder<TValue>.DisallowHtml()
        {
            return DisallowHtml();
        }

        [NotNull]
        IModelMetadataItemBuilder<TValue> IModelMetadataItemBuilder<TValue>.ShowForDisplay()
        {
            return ShowForDisplay();
        }

        [NotNull]
        IModelMetadataItemBuilder<TValue> IModelMetadataItemBuilder<TValue>.HideForDisplay()
        {
            return HideForDisplay();
        }

        [NotNull]
        IModelMetadataItemBuilder<TValue> IModelMetadataItemBuilder<TValue>.ShowForEdit()
        {
            return ShowForEdit();
        }

        [NotNull]
        IModelMetadataItemBuilder<TValue> IModelMetadataItemBuilder<TValue>.HideForEdit()
        {
            return HideForEdit();
        }

        [NotNull]
        IModelMetadataItemBuilder<TValue> IModelMetadataItemBuilder<TValue>.Show()
        {
            return Show();
        }

        [NotNull]
        IModelMetadataItemBuilder<TValue> IModelMetadataItemBuilder<TValue>.Hide()
        {
            return Hide();
        }

        [NotNull]
        IModelMetadataItemBuilder<TValue> IModelMetadataItemBuilder<TValue>.NullDisplayText(string value)
        {
            return NullDisplayText(value);
        }

        [NotNull]
        IModelMetadataItemBuilder<TValue> IModelMetadataItemBuilder<TValue>.NullDisplayText(Func<string> value)
        {
            return NullDisplayText(value);
        }

        [NotNull]
        IModelMetadataItemBuilder<TValue> IModelMetadataItemBuilder<TValue>.Watermark(string value)
        {
            return Watermark(value);
        }

        [NotNull]
        IModelMetadataItemBuilder<TValue> IModelMetadataItemBuilder<TValue>.Watermark(Func<string> value)
        {
            return Watermark(value);
        }

        [NotNull]
        IModelMetadataItemBuilder<TValue> IModelMetadataItemBuilder<TValue>.Order(int value)
        {
            return Order(value);
        }

        [NotNull]
        IModelMetadataItemBuilder<TValue> IModelMetadataItemBuilder<TValue>.DisplayFormat(string format)
        {
            return DisplayFormat(format);
        }

        [NotNull]
        IModelMetadataItemBuilder<TValue> IModelMetadataItemBuilder<TValue>.DisplayFormat(Func<string> format)
        {
            return DisplayFormat(format);
        }

        [NotNull]
        IModelMetadataItemBuilder<TValue> IModelMetadataItemBuilder<TValue>.EditFormat(string format)
        {
            return EditFormat(format);
        }

        [NotNull]
        IModelMetadataItemBuilder<TValue> IModelMetadataItemBuilder<TValue>.EditFormat(Func<string> format)
        {
            return EditFormat(format);
        }

        [NotNull]
        IModelMetadataItemBuilder<TValue> IModelMetadataItemBuilder<TValue>.Format(string value)
        {
            return Format(value);
        }

        [NotNull]
        IModelMetadataItemBuilder<TValue> IModelMetadataItemBuilder<TValue>.Format(Func<string> value)
        {
            return Format(value);
        }

        [NotNull]
        IModelMetadataItemBuilder<TValue> IModelMetadataItemBuilder<TValue>.ApplyFormatInEditMode()
        {
            return ApplyFormatInEditMode();
        }

        [NotNull]
        IModelMetadataItemBuilder<TValue> IModelMetadataItemBuilder<TValue>.Validate([NotNull] Func<TValue, bool> validator, string errorMessage)
        {
            return Validate(validator, errorMessage);
        }

        [NotNull]
        IModelMetadataItemBuilder<TValue> IModelMetadataItemBuilder<TValue>.Validate([NotNull] Func<TValue, bool> validator, [NotNull] Func<string> errorMessage)
        {
            return Validate(validator, errorMessage);
        }

        [NotNull]
        IModelMetadataItemBuilder<TValue> IModelMetadataItemBuilder<TValue>.Validate<TModel>([NotNull] Func<TModel, bool> validator, string errorMessage)
        {
            return Validate(validator, errorMessage);
        }

        [NotNull]
        IModelMetadataItemBuilder<TValue> IModelMetadataItemBuilder<TValue>.Validate<TModel>([NotNull] Func<TModel, bool> validator, [NotNull] Func<string> errorMessage)
        {
            return Validate(validator, errorMessage);
        }

        [NotNull]
        IModelMetadataItemBuilder<TValue> IModelMetadataItemBuilder<TValue>.ValidateBy<TValidator>()
        {
            return ValidateBy<TValidator>();
        }

        [NotNull]
        IModelMetadataItemBuilder<TValue> IModelMetadataItemBuilder<TValue>.ValidateBy<TValidator>(Action<TValidator> configure)
        {
            return ValidateBy(configure);
        }

        [NotNull]
        IModelMetadataItemBuilder<TValue> IModelMetadataItemBuilder<TValue>.ValidateBy<TValidator>(TValidator validator)
        {
            return ValidateBy(validator);
        }

        [NotNull]
        IModelMetadataItemBuilder<TValue> IModelMetadataItemBuilder<TValue>.ValidateBy<TValidator>(Func<ModelMetadata, ControllerContext, TValidator> factory)
        {
            return ValidateBy(factory);
        }

        [NotNull]
        IModelMetadataItemBuilder<TValue> IModelMetadataItemBuilder<TValue>.DisplayName(string value)
        {
            return DisplayName(value);
        }

        /// <summary>
        /// Sets the Display name.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns></returns>
        [NotNull]
        public ModelMetadataItemBuilder<TValue> DisplayName(string value)
        {
            return DisplayName(() => value);
        }

        /// <summary>
        /// Sets the Display name.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns></returns>
        [NotNull]
        public ModelMetadataItemBuilder<TValue> DisplayName(Func<string> value)
        {
            Item.DisplayName = value;

            return This;
        }

        /// <summary>
        /// Sets the short display name.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns></returns>
        [NotNull]
        public ModelMetadataItemBuilder<TValue> ShortDisplayName(string value)
        {
            return ShortDisplayName(() => value);
        }

        /// <summary>
        /// Sets the short display name.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns></returns>
        [NotNull]
        public ModelMetadataItemBuilder<TValue> ShortDisplayName(Func<string> value)
        {
            Item.ShortDisplayName = value;

            return This;
        }

        /// <summary>
        /// Sets the Templates name.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns></returns>
        [NotNull]
        public ModelMetadataItemBuilder<TValue> Template([AspMvcEditorTemplate, AspMvcDisplayTemplate] string value)
        {
            Item.TemplateName = value;

            return This;
        }

        /// <summary>
        /// Sets the Description.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns></returns>
        [NotNull]
        public ModelMetadataItemBuilder<TValue> Description(string value)
        {
            return Description(() => value);
        }

        /// <summary>
        /// Sets the Description.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns></returns>
        [NotNull]
        public ModelMetadataItemBuilder<TValue> Description(Func<string> value)
        {
            Item.Description = value;

            return This;
        }

        /// <summary>
        /// Marks the value as read only.
        /// </summary>
        /// <returns></returns>
        [NotNull]
        public ModelMetadataItemBuilder<TValue> ReadOnly()
        {
            Item.IsReadOnly = true;

            return This;
        }

        /// <summary>
        /// Marks the value as writable, this is handy when the framework initializes the
        /// value as read only and you want to negate it.
        /// </summary>
        /// <returns></returns>
        [NotNull]
        public ModelMetadataItemBuilder<TValue> Writable()
        {
            Item.IsReadOnly = false;

            return This;
        }

        /// <summary>
        /// Sets the other property that the value must match.
        /// </summary>
        /// <param name="otherProperty">The other property</param>
        /// <returns></returns>
        [NotNull]
        public ModelMetadataItemBuilder<TValue> Compare(string otherProperty)
        {
            return Compare(otherProperty, null, null, null);
        }

        /// <summary>
        /// Sets the other property that the value must match.
        /// </summary>
        /// <param name="otherProperty">The other property</param>
        /// <param name="errorMessage">The error message when the value is not specified.</param>
        /// <returns></returns>
        [NotNull]
        public ModelMetadataItemBuilder<TValue> Compare(string otherProperty, string errorMessage)
        {
            return Compare(otherProperty, () => errorMessage);
        }

        /// <summary>
        /// Sets the other property that the value must match.
        /// </summary>
        /// <param name="otherProperty">The other property</param>
        /// <param name="errorMessage">The error message when the value is not specified.</param>
        /// <returns></returns>
        [NotNull]
        public ModelMetadataItemBuilder<TValue> Compare(string otherProperty, Func<string> errorMessage)
        {
            return Compare(otherProperty, errorMessage, null, null);
        }

        /// <summary>
        /// Sets the other property that the value must match.
        /// </summary>
        /// <param name="errorMessageResourceType">Type of the error message resource.</param>
        /// <param name="errorMessageResourceName">Name of the error message resource.</param>
        /// <param name="otherProperty">The other property</param>
        /// <returns></returns>
        [NotNull]
        public ModelMetadataItemBuilder<TValue> Compare(string otherProperty, Type errorMessageResourceType, string errorMessageResourceName)
        {
            return Compare(otherProperty, null, errorMessageResourceType, errorMessageResourceName);
        }

        /// <summary>
        /// Marks the value as required.
        /// </summary>
        /// <returns></returns>
        [NotNull]
        public ModelMetadataItemBuilder<TValue> Required()
        {
            return Required(null, null, null);
        }

        /// <summary>
        /// Marks the value as required.
        /// </summary>
        /// <param name="errorMessage">The error message when the value is not specified.</param>
        /// <returns></returns>
        [NotNull]
        public ModelMetadataItemBuilder<TValue> Required(string errorMessage)
        {
            return Required(() => errorMessage);
        }

        /// <summary>
        /// Marks the value as required.
        /// </summary>
        /// <param name="errorMessage">The error message when the value is not specified.</param>
        /// <returns></returns>
        [NotNull]
        public ModelMetadataItemBuilder<TValue> Required(Func<string> errorMessage)
        {
            return Required(errorMessage, null, null);
        }

        /// <summary>
        /// Marks the value as required.
        /// </summary>
        /// <param name="errorMessageResourceType">Type of the error message resource.</param>
        /// <param name="errorMessageResourceName">Name of the error message resource.</param>
        /// <returns></returns>
        [NotNull]
        public ModelMetadataItemBuilder<TValue> Required(Type errorMessageResourceType, string errorMessageResourceName)
        {
            return Required(null, errorMessageResourceType, errorMessageResourceName);
        }

        /// <summary>
        /// Marks the value as optional, this is handy when the framework initializes the 
        /// value as required and you want to negate it.
        /// </summary>
        /// <returns></returns>
        [NotNull]
        public ModelMetadataItemBuilder<TValue> Optional()
        {
            Item.IsRequired = false;

            var requiredValidation = Item.GetValidation<RequiredValidationMetadata>();

            if (requiredValidation != null)
            {
                Item.Validations.Remove(requiredValidation);
            }

            return This;
        }

        /// <summary>
        /// Marks the value to render as hidden input element in edit mode.
        /// </summary>
        /// <returns></returns>
        [NotNull]
        public ModelMetadataItemBuilder<TValue> AsHidden()
        {
            Item.TemplateName = "HiddenInput";

            return This;
        }

        /// <summary>
        /// Marks the value to render as hidden input element in edit mode.
        /// </summary>
        /// <param name="hideSurroundingHtml">Indicates whether the value will appear in display mode</param>
        /// <returns></returns>
        [NotNull]
        public ModelMetadataItemBuilder<TValue> AsHidden(bool hideSurroundingHtml)
        {
            Item.TemplateName = "HiddenInput";
            Item.HideSurroundingHtml = hideSurroundingHtml;

            return This;
        }

        /// <summary>
        /// Hides surrounding HTML.
        /// </summary>
        /// <returns></returns>
        [NotNull]
        public ModelMetadataItemBuilder<TValue> HideSurroundingHtml()
        {
            Item.HideSurroundingHtml = true;

            return This;
        }

        /// <summary>
        /// Shows surrounding HTML.
        /// </summary>
        /// <returns></returns>
        [NotNull]
        public ModelMetadataItemBuilder<TValue> ShowSurroundingHtml()
        {
            Item.HideSurroundingHtml = false;

            return This;
        }

        /// <summary>
        /// Disables request validation for property.
        /// </summary>
        /// <returns></returns>
        [NotNull]
        public ModelMetadataItemBuilder<TValue> AllowHtml()
        {
            Item.RequestValidationEnabled = false;

            return This;
        }

        /// <summary>
        /// Enebles request validation for property.
        /// </summary>
        /// <returns></returns>
        [NotNull]
        public ModelMetadataItemBuilder<TValue> DisallowHtml()
        {
            Item.RequestValidationEnabled = true;

            return This;
        }

        /// <summary>
        /// Shows the value in display mode.
        /// </summary>
        /// <returns></returns>
        [NotNull]
        public ModelMetadataItemBuilder<TValue> ShowForDisplay()
        {
            Item.ShowForDisplay = true;

            return This;
        }

        /// <summary>
        /// Hides the value in display mode.
        /// </summary>
        /// <returns></returns>
        [NotNull]
        public ModelMetadataItemBuilder<TValue> HideForDisplay()
        {
            Item.ShowForDisplay = false;

            return This;
        }

        /// <summary>
        /// Shows the value in edit mode.
        /// </summary>
        /// <returns></returns>
        [NotNull]
        public ModelMetadataItemBuilder<TValue> ShowForEdit()
        {
            Item.ShowForEdit = true;

            return This;
        }

        /// <summary>
        /// Hides the value in edit mode.
        /// </summary>
        /// <returns></returns>
        [NotNull]
        public ModelMetadataItemBuilder<TValue> HideForEdit()
        {
            Item.ShowForEdit = false;

            return This;
        }

        /// <summary>
        /// Shows the value in both display and edit mode.
        /// </summary>
        /// <returns></returns>
        [NotNull]
        public ModelMetadataItemBuilder<TValue> Show()
        {
            Item.ShowForDisplay = true;
            Item.ShowForEdit = true;

            return This;
        }

        /// <summary>
        /// Hides the value in both display and edit mode.
        /// </summary>
        /// <returns></returns>
        [NotNull]
        public ModelMetadataItemBuilder<TValue> Hide()
        {
            Item.ShowForDisplay = false;
            Item.ShowForEdit = false;

            return This;
        }

        /// <summary>
        /// Sets the display text when the value is null.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns></returns>
        [NotNull]
        public ModelMetadataItemBuilder<TValue> NullDisplayText(string value)
        {
            return NullDisplayText(() => value);
        }

        /// <summary>
        /// Sets the display text when the value is null.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns></returns>
        [NotNull]
        public ModelMetadataItemBuilder<TValue> NullDisplayText(Func<string> value)
        {
            Item.NullDisplayText = value;

            return This;
        }

        /// <summary>
        /// Sets the Watermark.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns></returns>
        [NotNull]
        public ModelMetadataItemBuilder<TValue> Watermark(string value)
        {
            return Watermark(() => value);
        }

        /// <summary>
        /// Sets the Watermark.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns></returns>
        [NotNull]
        public ModelMetadataItemBuilder<TValue> Watermark(Func<string> value)
        {
            Item.Watermark = value;

            return This;
        }

        /// <summary>
        /// Sets the order
        /// </summary>
        /// <param name="value">The order</param>
        /// <returns></returns>
        [NotNull]
        public ModelMetadataItemBuilder<TValue> Order(int value)
        {
            Item.Order = value;
            return This;
        }

        /// <summary>
        /// Sets the format in display mode.
        /// </summary>
        /// <param name="format">The value.</param>
        /// <returns></returns>
        [NotNull]
        public ModelMetadataItemBuilder<TValue> DisplayFormat(string format)
        {
            return DisplayFormat(() => format);
        }

        /// <summary>
        /// Sets the format in display mode.
        /// </summary>
        /// <param name="format">The value.</param>
        /// <returns></returns>
        [NotNull]
        public ModelMetadataItemBuilder<TValue> DisplayFormat(Func<string> format)
        {
            Item.DisplayFormat = format;

            return This;
        }

        /// <summary>
        /// Sets the format in edit mode.
        /// </summary>
        /// <param name="format">The format.</param>
        /// <returns></returns>
        [NotNull]
        public ModelMetadataItemBuilder<TValue> EditFormat(string format)
        {
            return EditFormat(() => format);
        }

        /// <summary>
        /// Sets the format in edit mode.
        /// </summary>
        /// <param name="format">The format.</param>
        /// <returns></returns>
        [NotNull]
        public ModelMetadataItemBuilder<TValue> EditFormat(Func<string> format)
        {
            Item.EditFormat = format;

            return This;
        }

        /// <summary>
        /// Sets format for both display and edit mode.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns></returns>
        [NotNull]
        public ModelMetadataItemBuilder<TValue> Format(string value)
        {
            return Format(() => value);
        }

        /// <summary>
        /// Sets format for both display and edit mode.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns></returns>
        [NotNull]
        public ModelMetadataItemBuilder<TValue> Format(Func<string> value)
        {
            Item.DisplayFormat = Item.EditFormat = value;

            return This;
        }

        /// <summary>
        /// Indicates to apply format in edit mode.
        /// </summary>
        /// <returns></returns>
        [NotNull]
        public ModelMetadataItemBuilder<TValue> ApplyFormatInEditMode()
        {
            Item.ApplyFormatInEditMode = true;

            return This;
        }

        /// <summary>
        /// Sets the delegate based custom validation for value.
        /// </summary>
        /// <returns></returns>
        [NotNull]
        public ModelMetadataItemBuilder<TValue> Validate([NotNull] Func<TValue, bool> validator, string errorMessage = null)
        {
            var message = string.IsNullOrEmpty(errorMessage)
                              ? "The {0} value is invalid."
                              : errorMessage;

            return Validate<object>((container, value) => validator(value), () => message);
        }

        /// <summary>
        /// Sets the delegate based custom validation for value.
        /// </summary>
        /// <returns></returns>
        [NotNull]
        public ModelMetadataItemBuilder<TValue> Validate([NotNull] Func<TValue, bool> validator, [NotNull] Func<string> errorMessage)
        {
            return Validate<object>((container, value) => validator(value), errorMessage);
        }

        /// <summary>
        /// Sets the delegate based custom validation for value.
        /// </summary>
        /// <returns></returns>
        [NotNull]
        public ModelMetadataItemBuilder<TValue> Validate<TModel>([NotNull] Func<TModel, bool> validator, string errorMessage = null)
        {
            var message = string.IsNullOrEmpty(errorMessage)
                              ? "The {0} value is invalid."
                              : errorMessage;

            return Validate<TModel>((container, value) => validator(container), () => message);
        }

        /// <summary>
        /// Sets the delegate based custom validation for value.
        /// </summary>
        /// <returns></returns>
        [NotNull]
        public ModelMetadataItemBuilder<TValue> Validate<TModel>([NotNull] Func<TModel, bool> validator, [NotNull] Func<string> errorMessage)
        {
            return Validate<TModel>((container, value) => validator(container), errorMessage);
        }

        /// <summary>
        /// Sets the <typeparamref name="TValidator"/> to validate value.
        /// </summary>
        /// <typeparam name="TValidator">The type of validator</typeparam>
        /// <returns></returns>
        [NotNull]
        public ModelMetadataItemBuilder<TValue> ValidateBy<TValidator>()
            where TValidator : ModelValidator
        {
            return ValidateBy<TValidator>(v => { });
        }

        /// <summary>
        /// Sets the <typeparamref name="TValidator"/> to validate value.
        /// </summary>
        /// <typeparam name="TValidator">The type of validator</typeparam>
        /// <param name="configure">The configuration</param>
        /// <returns></returns>
        [NotNull]
        public ModelMetadataItemBuilder<TValue> ValidateBy<TValidator>(Action<TValidator> configure)
            where TValidator : ModelValidator
        {
            return ValidateBy(CreateFactory<TValidator>(), configure);
        }

        /// <summary>
        /// Sets the <typeparamref name="TValidator"/> to validate value.
        /// </summary>
        /// <typeparam name="TValidator">The type of validator</typeparam>
        /// <param name="validator">The instance of validator</param>
        /// <returns></returns>
        [NotNull]
        public ModelMetadataItemBuilder<TValue> ValidateBy<TValidator>(TValidator validator)
            where TValidator : ModelValidator
        {
            return ValidateBy((m, c) => validator);
        }

        /// <summary>
        /// Sets the <typeparamref name="TValidator"/> to validate value.
        /// </summary>
        /// <typeparam name="TValidator">The type of validator</typeparam>
        /// <param name="factory">The factory used to build validator</param>
        /// <returns></returns>
        [NotNull]
        public ModelMetadataItemBuilder<TValue> ValidateBy<TValidator>(Func<ModelMetadata, ControllerContext, TValidator> factory)
            where TValidator : ModelValidator
        {
            return ValidateBy(factory, v => { });
        }

        /// <summary>
        /// Sets the delegate based custom validation for model and value.
        /// </summary>
        /// <returns></returns>
        [NotNull]
        protected virtual ModelMetadataItemBuilder<TValue> Validate<TModel>([NotNull] Func<TModel, TValue, bool> validator, [NotNull] Func<string> errorMessage)
        {
            Invariant.IsNotNull(errorMessage, "errorMessage");

            return ValidateBy((m, c) => new DelegateBasedValidator(m, c, (container, value) => validator((TModel)container, (TValue)value))
                                            {
                                                ErrorMessage = errorMessage()
                                            });
        }

        /// <summary>
        /// Sets the <typeparamref name="TValidator"/> to validate value.
        /// </summary>
        /// <typeparam name="TValidator">The type of validator</typeparam>
        /// <param name="factory">The factory used to build validator</param>
        /// <param name="configure">The configuration</param>
        /// <returns></returns>
        [NotNull]
        protected virtual ModelMetadataItemBuilder<TValue> ValidateBy<TValidator>(Func<ModelMetadata, ControllerContext, TValidator> factory, Action<TValidator> configure)
            where TValidator : ModelValidator
        {
            var validation = Item.GetValidationOrCreateNew<CustomValidationMetadata<TValidator>>();

            validation.Factory = factory;
            validation.Configure = configure;

            return this;
        }

        /// <summary>
        /// Marks the value as required.
        /// </summary>
        /// <param name="errorMessage">The error message.</param>
        /// <param name="errorMessageResourceType">Type of the error message resource.</param>
        /// <param name="errorMessageResourceName">Name of the error message resource.</param>
        /// <returns></returns>
        [NotNull]
        protected virtual ModelMetadataItemBuilder<TValue> Required(Func<string> errorMessage, Type errorMessageResourceType, string errorMessageResourceName)
        {
            Item.IsRequired = true;

            var validation = Item.GetValidationOrCreateNew<RequiredValidationMetadata>();

            validation.ErrorMessage = errorMessage;
            validation.ErrorMessageResourceType = errorMessageResourceType;
            validation.ErrorMessageResourceName = errorMessageResourceName;

            return This;
        }

        /// <summary>
        /// Sets the other property that the value must match.
        /// </summary>
        /// <param name="otherProperty">The other property.</param>
        /// <param name="errorMessage">The error message.</param>
        /// <param name="errorMessageResourceType">Type of the error message resource.</param>
        /// <param name="errorMessageResourceName">Name of the error message resource.</param>
        /// <returns></returns>
        [NotNull]
        protected virtual ModelMetadataItemBuilder<TValue> Compare(string otherProperty, Func<string> errorMessage, Type errorMessageResourceType, string errorMessageResourceName)
        {
            var compareValidation = Item.GetValidationOrCreateNew<CompareValidationMetadata>();

            compareValidation.OtherProperty = otherProperty;
            compareValidation.ErrorMessage = errorMessage;
            compareValidation.ErrorMessageResourceType = errorMessageResourceType;
            compareValidation.ErrorMessageResourceName = errorMessageResourceName;

            return This;
        }

        [NotNull]
        private static Func<ModelMetadata, ControllerContext, TValidator> CreateFactory<TValidator>() where TValidator : ModelValidator
        {
            var validatorType = typeof(TValidator);
            ConstructorInfo constructor = validatorType
                .GetConstructor(new[] { typeof(ModelMetadata), typeof(ControllerContext) });

            if (constructor == null)
            {
                throw new ArgumentException(string.Format(CultureInfo.CurrentCulture, "The constructor of {0} that takes an ModelMetadata and ControllerContext as a parameters is not available.", validatorType));
            }

            var modelMetadata = Expression.Parameter(typeof(ModelMetadata));
            var controllerContext = Expression.Parameter(typeof(ControllerContext));
            var @new = Expression.New(constructor, modelMetadata, controllerContext);

            return Expression.Lambda<Func<ModelMetadata, ControllerContext, TValidator>>(@new, modelMetadata, controllerContext).Compile();
        }
    }
}