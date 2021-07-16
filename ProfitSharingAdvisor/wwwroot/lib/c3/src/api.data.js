import { Chart } from './core';
import { isArray } from './util';
Chart.prototype.data = function (targetIds) {
    var targets = this.internal.data.targets;
    return typeof targetIds === 'undefined'
        ? targets
        : targets.filter(function (t) {
            return [].concat(targetIds).indexOf(t.id) >= 0;
        });
};
Chart.prototype.data.shown = function (targetIds) {
    return this.internal.filterTargetsToShow(this.data(targetIds));
};
/**
 * Get values of the data loaded in the chart.
 *
 * @param {String|Array} targetId This API returns the value of specified target.
 * @param flat
 * @return {Array} Data values
 */
Chart.prototype.data.values = function (targetId, flat) {
    if (flat === void 0) { flat = true; }
    var values = null;
    if (targetId) {
        var targets = this.data(targetId);
        if (targets && isArray(targets)) {
            values = targets.reduce(function (ret, v) {
                var dataValue = v.values.map(function (d) { return d.value; });
                if (flat) {
                    ret = ret.concat(dataValue);
                }
                else {
                    ret.push(dataValue);
                }
                return ret;
            }, []);
        }
    }
    return values;
};
Chart.prototype.data.names = function (names) {
    this.internal.clearLegendItemTextBoxCache();
    return this.internal.updateDataAttributes('names', names);
};
Chart.prototype.data.colors = function (colors) {
    return this.internal.updateDataAttributes('colors', colors);
};
Chart.prototype.data.axes = function (axes) {
    return this.internal.updateDataAttributes('axes', axes);
};
Chart.prototype.data.stackNormalized = function (normalized) {
    if (normalized === undefined) {
        return this.internal.isStackNormalized();
    }
    this.internal.config.data_stack_normalize = !!normalized;
    this.internal.redraw();
};
